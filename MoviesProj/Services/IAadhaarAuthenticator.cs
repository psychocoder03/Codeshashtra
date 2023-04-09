namespace MoviesProj.Services
{
    public interface IAadhaarAuthenticator
    {
        Task CallExternalApiAndInsertDocumentAsync(string secretKey, string clientId, string aadhaarNumber);
        Task SubmitOtpAsync(string secretKey, string clientId, string otp);
    }
}
