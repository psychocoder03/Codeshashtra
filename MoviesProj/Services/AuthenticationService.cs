using LoggerService;
using MongoDB.Driver;
using MoviesProj.Models;
using MoviesProj.Models.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MoviesProj.Services
{
    //internal sealed class AuthenticationService
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private User _user;
        public AuthenticationService(ILoggerManager logger, IConfiguration configuration, IMongoClient mongoClient, IMovieDatabaseSettings settings)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userCollection = database.GetCollection<User>(settings.UserCollectionName);
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<bool> userExists(string email)
        {
            return await _userCollection.Find(user => user.Email == email).AnyAsync();
        }
        public async Task<User> RegisterUser(User user)
        {
            await _userCollection.InsertOneAsync(user);
            Console.WriteLine();
            return user;
        }
        public async Task<bool> ValidateUser(UserForAuthentication userForAuth)
        {
            if (!await _userCollection.Find(user => user.Email == userForAuth.Email).AnyAsync())
            {
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. No such email exists.");
                return false;
            }
            _user = await _userCollection.Find(user => user.Email == userForAuth.Email).FirstOrDefaultAsync();
            Console.WriteLine(_user.Email);
            Console.WriteLine(_user.Password);
            var result = (_user != null && _user.Password == userForAuth.Password);
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong email or password.");
            return result;
        }
    }
}
