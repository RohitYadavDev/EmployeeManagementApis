using DemoApis.DTOs.Requests;
using DemoApis.DTOs.Responses;
using Microsoft.AspNetCore.Identity.Data;

namespace DemoApis.Services
{
    public interface IEmployeeService
    {
        Task<ApiResponse<RegisterResponseDto>> RegisterEmployeeAsync(RegistrationDTOs employeeModel);
    }
}
