using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesProj.Models;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [Route("api/employer")]
    [ApiController]
    public class EmployerController : Controller
    {
        private readonly IEmployerService employerService;

        public EmployerController(IEmployerService employerService)
        {
            this.employerService = employerService;
        }

        //// GET: CommentsController
        //[HttpGet]
        //public async Task<ActionResult> Index(int pageNo = 1)
        //{
        //    return Ok(await commentService.Get(pageNo));
        //}

        //[ApiExplorerSettings(GroupName = "v1")]
        //[ApiVersion("1.0", Deprecated = true)]
        // GET: CommentsController/Details/5
        [HttpGet("{email}")]
        public async Task<ActionResult> Details(string email)
        {
            var employer = await employerService.Get(email);
            if (employer == null)
                return NotFound($"Employer with EMail {email} not found.");
            return Ok(employer);
        }

        // POST: CommentsController/Create
        [HttpPost]
        //[]
        public async Task<ActionResult> Create(Employer employer)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            //if (await employerService.Get(employer.Email) == null)
            //    return BadRequest("No employer exists for specified email Id.");
            return Ok(await employerService.Create(employer));
        }

        [HttpPut("{email}")]
        public async Task<ActionResult> Edit(string email, [FromBody] Employer employer)
        {
            if (employer.Email != email)
                return BadRequest("Email Id cannot be different.");
            var existingEmployer = await employerService.Get(email);
            if (existingEmployer == null)
                return NotFound($"Employer with EMail {email} not found.");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (employer.Email != existingEmployer.Email)
                return BadRequest("You cannot change Employer Email Id.");

            return Ok(await employerService.Update(email, employer));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string email)
        {
            var employerToBeDeleted = await employerService.Get(email);
            if (employerToBeDeleted == null)
                return NotFound($"Employer with Email Id {email} not found");
            await employerService.Delete(email);
            return Ok($"Employer with Email {email} deleted");
        }
    }
}
