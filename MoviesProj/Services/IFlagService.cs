using MoviesProj.Models;

namespace MoviesProj.Services
{
    public interface IFlagService
    {
        Task<string> GetOutputColour(string email);
        Task<Flags> GetEmail(string email);
        Task<Flags> GetAadhaar(string aadhaar);
        Task<Flags> Update(string email, string colour);
        Task<Flags> Create(string email, string colour);
    }
}
