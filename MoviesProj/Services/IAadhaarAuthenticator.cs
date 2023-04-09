using MoviesProj.Models;

namespace MoviesProj.Services
{
    public interface IAadhaarAuthenticator
    {
        Task CallExternalApiAndInsertDocumentAsync(string secretKey, string clientId, string aadhaarNumber,string email);
        Task SubmitOtpAsync(string secretKey, string clientId, string otp, string email);
        Task<SendAadhaar> SendAadhaarDetails(string email); 
    }
}
