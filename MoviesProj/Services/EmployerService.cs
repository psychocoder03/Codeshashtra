using MongoDB.Driver;
using MoviesProj.Models;

namespace MoviesProj.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IMongoCollection<Employer> _employer;

        public EmployerService(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _employer = database.GetCollection<Employer>(settings.EmployerCollectionName);
        }

        public async Task<Employer> Get(string email)
        {
            return await _employer.Find(employer => employer.Email == email).FirstOrDefaultAsync();
        }
        public async Task<Employer> Create(Employer employer)
        {
            await _employer.InsertOneAsync(employer);
            return employer;
        }
        public async Task<Employer> Update(string email, Employer employer)
        {
            Employer existingEmployer = await Get(email);
            employer.Id = existingEmployer.Id;
            _employer.ReplaceOne(employer => employer.Email == email, employer);
            return await _employer.Find(sp => sp.Email == email).FirstOrDefaultAsync();

        }
        public async Task Delete(string email)
        {
            await _employer.DeleteOneAsync(employer => employer.Email == email);
        }
    }
}
