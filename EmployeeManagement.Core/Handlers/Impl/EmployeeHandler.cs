using EmployeeManagement.Domain.Models;
using EmployeeManagement.Persistence.Managers;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Core.Handlers.Impl
{
    internal class EmployeeHandler : IEmployeeHandler
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly ILogger<EmployeeHandler> _logger;

        public EmployeeHandler(IEmployeeManager employeeManager, ILogger<EmployeeHandler> logger) 
        {
            _employeeManager = employeeManager;
            _logger = logger;
        }

        public Employee CreateEmployee(Employee employee)
        {
            var source = $"{nameof(EmployeeHandler)}.{nameof(CreateEmployee)}";
            try
            {
                return _employeeManager.AddEmployee(employee);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to save [{nameof(Employee)}] with Employee Number: [{employee.EmployeeNum}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            var source = $"{nameof(EmployeeHandler)}.{nameof(DeleteEmployee)}";
            try
            {
                _employeeManager.RemoveEmployee(employeeId);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to delete [{nameof(Employee)}] with Employee ID: [{employeeId}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var source = $"{nameof(EmployeeHandler)}.{nameof(GetAllEmployees)}";
            try
            {
               return _employeeManager.GetAllEmployees();
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to retrieve [{nameof(Employee)}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var source = $"{nameof(EmployeeHandler)}.{nameof(DeleteEmployee)}";
            try
            {
                return _employeeManager.UpdateEmployee(employee);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to update [{nameof(Employee)}] with Employee Number: [{employee.EmployeeNum}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }
    }
}
