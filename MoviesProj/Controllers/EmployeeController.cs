using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesProj.Models;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeContoller : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeContoller(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult> Get(string email)
        {
            var employee = await employeeService.Get(email);
            if (employee == null)
                return NotFound($"Employee with Email {email} not found.");
           return Ok(employee);
        }

        [HttpGet("all/{email}")]
        public async Task<ActionResult> Details(string email)
        {
            var employee = await employeeService.GetEmployee(email);
            if (employee == null)
                return NotFound($"Employee with Email {email} not found.");
            return Ok(employee);
        }

        // POST: CommentsController/Create
        [HttpPost]
        //[]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            //if (await employerService.Get(employer.Email) == null)
            //    return BadRequest("No employer exists for specified email Id.");
            return Ok(await employeeService.Create(employee));
        }

        [HttpPut("{email}")]
        public async Task<ActionResult> Edit(string email, [FromBody] Employee employee)
        {
            var existingEmployee = await employeeService.Get(employee.EmployeeEmail);
            if (existingEmployee == null)
                return NotFound($" Employee with Email {employee.EmployeeEmail} not found.");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            return Ok(await employeeService.Update(employee));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string email)
        {
            var employeeToBeDeleted = await employeeService.Get(email);
            if (employeeToBeDeleted == null)
                return NotFound($"Employee with Email Id {email} not found");
            await employeeService.Delete(email);
            return Ok($"Employee with Email {email} deleted");
        }


    }
}
