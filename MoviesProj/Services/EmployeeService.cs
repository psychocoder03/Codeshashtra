using MongoDB.Driver;
using MoviesProj.Models;

namespace MoviesProj.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeService(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _employee = database.GetCollection<Employee>(settings.EmployeeCollectionName);
        }
        public async Task<Employee> Get(string email)
        {
            return await _employee.Find(employee => employee.EmployeeEmail == email).FirstOrDefaultAsync();
        }
        public async Task<Employee> Create(Employee employee)
        {
            await _employee.InsertOneAsync(employee);
            return employee;
        }
        public async Task<Employee> Update(Employee employee)
        {
            Employee existingEmployee = await Get(employee.EmployeeEmail);
            employee.Id = existingEmployee.Id;
            _employee.ReplaceOne(employee => employee.EmployeeEmail == existingEmployee.EmployeeEmail, employee);
            return await _employee.Find(sp => sp.EmployeeEmail == employee.EmployeeEmail).FirstOrDefaultAsync();
        }
        public async Task Delete(string email)
        {
            await _employee.DeleteOneAsync(employee => employee.EmployeeEmail == email);
        }
    }
}
