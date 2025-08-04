using DemoApis.DTOs.Requests;
using DemoApis.DTOs.Responses;
using DemoApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoApis.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterEmployeeAsync([FromBody] RegistrationDTOs employeeModel)
        {
            var result = await _employeeService.RegisterEmployeeAsync(employeeModel);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result); 
        }



    }
}
