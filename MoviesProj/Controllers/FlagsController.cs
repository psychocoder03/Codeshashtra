using Microsoft.AspNetCore.Mvc;
using MoviesProj.Models;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [ApiController]
    public class FlagsController : Controller
    {
        private readonly IFlagService flagService;
        public FlagsController(IFlagService flagService)
        {
            this.flagService = flagService;
        }
        [Route("api/flagcolour/{email}")]
        // GET: SpecCommentsController
        [HttpGet]
        public async Task<ActionResult> OutputColour(string email)
        {
            return Ok(await flagService.GetOutputColour(email));
        }

        [Route("api/emailflags/{email}")]
        // GET: SpecCommentsController
        [HttpGet]
        public async Task<ActionResult> EmailFlag(string email)
        {
            return Ok(await flagService.GetEmail(email));
        }

        
        [Route("api/aadhaarflags/{aadhaar}")]
        // GET: SpecCommentsController
        [HttpGet]
        public async Task<ActionResult> AadhaarFlag(string aadhaar)
        {
            return Ok(await flagService.GetAadhaar(aadhaar));
        }

        
        [Route("api/flags/{email}/{colour}")]
        [HttpGet]
        // GET: SpecCommentsController
        public async Task<ActionResult> CreateUpdate(string email,string colour)
        {
            return Ok(await flagService.Create(email,colour));
        }
    }
}
