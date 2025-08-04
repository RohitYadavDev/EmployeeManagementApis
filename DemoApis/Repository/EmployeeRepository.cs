using DemoApis.DBContext;
using DemoApis.DTOs.Requests;
using DemoApis.DTOs.Responses;
using DemoApis.Models.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoApis.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiDBContext _context;
        public EmployeeRepository(ApiDBContext apiDBContext)
        {
            _context = apiDBContext;
        }
        public async Task<ApiResponse<RegisterResponseDto>> RegisterEmployee(RegistrationDTOs employeeModel)
        {
            try
            {
                // Check if username already exists
                var existingEmployee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Username.ToLower() == employeeModel.Username.ToLower());
                if (existingEmployee != null)
                {
                    return new ApiResponse<RegisterResponseDto>(
                        success: false,
                        message: Helpers.Constants.MessageConstants.UserNameExists,
                        data: null
                    );
                }

                // Check if email already exists
                var existingEmail = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Email.ToLower() == employeeModel.Email.ToLower());
                if (existingEmail != null)
                {
                    return new ApiResponse<RegisterResponseDto>(
                        success: false,
                        message: Helpers.Constants.MessageConstants.UserAlreadyExists,
                        data: null
                    );
                }

                // Create new employee entity
                var employee = new Employee
                {
                    FirstName = employeeModel.FirstName,
                    MiddleName = employeeModel.MiddleName,
                    LastName = employeeModel.LastName,
                    Username = employeeModel.Username,
                    Password = employeeModel.Password, // Optional: Encrypt here
                    Email = employeeModel.Email,
                    PhoneNumber = employeeModel.PhoneNumber,
                    Gender = employeeModel.Gender,
                    DateOfBirth = employeeModel.DateOfBirth,
                    DepartmentId = employeeModel.DepartmentId,
                    DesignationId = employeeModel.DesignationId,
                    EmergencyContactName = employeeModel.EmergencyContactName,
                    EmergencyContactNumber = employeeModel.EmergencyContactNumber,
                    EmployeeCode = "EMP" + _context.Employees.Count(),

                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                // Prepare response DTO
                var responseDto = new RegisterResponseDto
                {
                    EmployeeId = employee.EmployeeId,
                    Username = employee.Username,
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    Email = employee.Email
                };

                return new ApiResponse<RegisterResponseDto>(
                    success: true,
                    message: Helpers.Constants.MessageConstants.RegistrationSuccess,
                    data: responseDto
                );
            }
            catch (Exception ex)
            {
                // Optional: Log the exception
                return new ApiResponse<RegisterResponseDto>(
                    success: false,
                    message: Helpers.Constants.MessageConstants.RegistrationFailed,
                    data: null
                );
            }
        }
    }
}
