using Microsoft.AspNetCore.Mvc;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [Route("api/aadhaar")]
    [ApiController]
    public class AadhaarController : Controller
    {
        private readonly IAadhaarAuthenticator aadhaarService;

        public AadhaarController(IAadhaarAuthenticator aadhaarService)
        {
            this.aadhaarService = aadhaarService;
        }

        [HttpGet("{email}/{aadhaarNumber}")]
        public async Task<ActionResult> Get(string email,string aadhaarNumber)
        {
            await aadhaarService.CallExternalApiAndInsertDocumentAsync("iaOte65IcLkUG0ejtjOtc2kFBntHFbmeWoi3aTW6zIlQ9NfoV4c3U4QIumep1knzs", "63bdac23db031848ad320ad11c4781b4:730a7a0e994711d4257bc0b2b0f069a6", aadhaarNumber);
            return Ok();
        }

        [HttpGet("all/{email}/{otp}")]
        public async Task<ActionResult> Details(string email, string otp)
        {
            Console.WriteLine(email);
            Console.WriteLine(otp);
            //await aadhaarService.SubmitOtpAsync("iaOte65IcLkUG0ejtjOtc2kFBntHFbmeWoi3aTW6zIlQ9NfoV4c3U4QIumep1knzs", "63bdac23db031848ad320ad11c4781b4:730a7a0e994711d4257bc0b2b0f069a6", otp);
            return Ok();
        }
    }
}
