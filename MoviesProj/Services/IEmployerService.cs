using MoviesProj.Models;

namespace MoviesProj.Services
{
    public interface IEmployerService
    {
        //Task<List<Employer>> Get(int pageNo);
        Task<Employer> Get(string email);
        Task<Employer> Create(Employer employer);
        Task<Employer> Update(string email, Employer employer);
        Task Delete(string email);
    }
}
