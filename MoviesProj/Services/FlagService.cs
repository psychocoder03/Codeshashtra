using MongoDB.Driver;
using MoviesProj.Models;

namespace MoviesProj.Services
{
    public class FlagService : IFlagService
    {
        private readonly IMongoCollection<Flags> _flags;
        private readonly IMongoCollection<Employee> _employee;

        public FlagService(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _flags = database.GetCollection<Flags>(settings.FlagCollectionName);
            _employee = database.GetCollection<Employee>(settings.EmployeeCollectionName);
        }
        public async Task<string> GetOutputColour(string email)
        {
            var flagsemail = await _flags.Find(flag => flag.Email == email).FirstOrDefaultAsync();
            string outputColor = "green";
            if (flagsemail.Flag.Contains("red"))
            {
                outputColor = "red";
            }
            else if (flagsemail.Flag.Contains("yellow"))
            {
                outputColor = "yellow";
            }
            return outputColor;
        }
        public async Task<Flags> GetEmail(string email)
        {
            return await _flags.Find(flag => flag.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Flags> GetAadhaar(string aadhaar)
        {
            return await _flags.Find(flag => flag.Aadhaar == aadhaar).FirstOrDefaultAsync();
        }

        public async Task<Flags> Create(string email, string colour)
        {
            Flags existingFlag = await GetEmail(email);
            if(existingFlag != null)
            {
                var newsFlag = await Update(email, colour);
                UpdateFlags(email);
                return newsFlag;
            }
            string[] flagValues = new string[] { colour };
            Flags newFlag = new Flags() { Email = email, Flag = flagValues };
            await _flags.InsertOneAsync(newFlag);
            UpdateFlags(email);
            return newFlag;
        }

        public async Task<Flags> Update(string email, string colour)
        {
            Flags existingFlag = await GetEmail(email);
            existingFlag.Flag.Append(colour);
            _flags.ReplaceOne(flag => flag.Email == email, existingFlag);
            UpdateFlags(email);
            return await _flags.Find(sp => sp.Email == email).FirstOrDefaultAsync();
        }


        private async Task UpdateFlags (string email)
        {
            Flags existingFlag = await GetEmail(email);
            Employee existingEmployee = await _employee.Find(employee => employee.EmployeeEmail == email).FirstOrDefaultAsync();
            existingEmployee.Flag = await GetOutputColour(email);
            await _employee.ReplaceOneAsync(employee => employee.EmployeeEmail == email, existingEmployee);
        }
    }
}
