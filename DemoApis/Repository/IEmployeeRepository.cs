using DemoApis.DTOs.Requests;
using DemoApis.DTOs.Responses;
using System.ClientModel.Primitives;

namespace DemoApis.Repository
{
    public interface IEmployeeRepository
    {
        Task<ApiResponse<RegisterResponseDto>> RegisterEmployee(RegistrationDTOs employeeModel);
    }
}
