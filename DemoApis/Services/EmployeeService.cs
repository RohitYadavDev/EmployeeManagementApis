using DemoApis.DTOs.Requests;
using DemoApis.DTOs.Responses;
using DemoApis.Repository;

namespace DemoApis.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ApiResponse<RegisterResponseDto>> RegisterEmployeeAsync(RegistrationDTOs employeeModel)
        {
            try
            {
                if (employeeModel == null)
                {
                    return new ApiResponse<RegisterResponseDto>(
                        success: false,
                        message: Helpers.Constants.MessageConstants.EmptyDataError,
                        data: null
                    );
                }

                // Hash sensitive data
                employeeModel.Password = Helpers.SecurityHelper.HashPassword(employeeModel.Password);
                employeeModel.Username = employeeModel.Username.ToLower(); //  hashing username unless required

                // Call repository
                return await _employeeRepository.RegisterEmployee(employeeModel);
            }
            catch (Exception ex)
            {
                // Optionally log ex here

                return new ApiResponse<RegisterResponseDto>(
                    success: false,
                    message: Helpers.Constants.MessageConstants.InternalServerError,
                    data: null
                );
            }
        }

    }
}

