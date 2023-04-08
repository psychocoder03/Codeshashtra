using MoviesProj.Models;

namespace MoviesProj.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Get(string email);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task Delete(string email);

    }
}
