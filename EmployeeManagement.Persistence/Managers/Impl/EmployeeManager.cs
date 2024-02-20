using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Persistence.Managers.Impl
{
    internal class EmployeeManager : IEmployeeManager
    {
        private readonly EmployeeManagementContext _employeeManagementContext;
        private readonly ILogger<EmployeeManager> _logger;

        public EmployeeManager(EmployeeManagementContext employeeManagementContext, ILogger<EmployeeManager> logger) 
        {
            _employeeManagementContext = employeeManagementContext;
            _logger = logger;
        }

        public Employee AddEmployee(Employee employee)
        {
            var source = $"{nameof(EmployeeManager)}.{nameof(AddEmployee)}";
            using var transaction = _employeeManagementContext.Database.BeginTransaction();
            try
            {
                employee.EmployedDate = DateTime.Now;

                _employeeManagementContext.Add(employee);
                _employeeManagementContext.SaveChanges();
                transaction.Commit();

                return employee;
            }
            catch (Exception exception)
            {
                transaction.Rollback();

                var errorMessage = $"[{source}]: Something went wrong while trying to add [{nameof(Employee)}] with Employee Number: [{employee.EmployeeNum}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var source = $"{nameof(EmployeeManager)}.{nameof(GetAllEmployees)}";
            try
            {
                return _employeeManagementContext.Employees.Include(e => e.Person).ToList();
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to retrieve [{nameof(Employee)}]s. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public void RemoveEmployee(int employeeId)
        {
            var source = $"{nameof(EmployeeManager)}.{nameof(RemoveEmployee)}";
            using var transaction = _employeeManagementContext.Database.BeginTransaction();
            try
            {
                var employeeToRemove = _employeeManagementContext.Employees.Find(employeeId);

                if (employeeToRemove != null)
                {
                    _employeeManagementContext.Remove(employeeToRemove);
                    _employeeManagementContext.SaveChanges();
                    transaction.Commit();
                }
            }
            catch (Exception exception)
            {
                transaction.Rollback();

                var errorMessage = $"[{source}]: Something went wrong while trying to remove [{nameof(Employee)}] with Employee ID: [{employeeId}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var source = $"{nameof(EmployeeManager)}.{nameof(UpdateEmployee)}";
            using var transaction = _employeeManagementContext.Database.BeginTransaction();

            try
            {
                var existingEmployee = _employeeManagementContext.Employees
                    .Include(e => e.Person)
                    .FirstOrDefault(e => e.Id == employee.Id);

                if (existingEmployee != null)
                {
                    // Update properties of the existing employee
                    existingEmployee.EmployeeNum = employee.EmployeeNum;
                    existingEmployee.EmployedDate = employee.EmployedDate;
                    existingEmployee.TerminatedDate = employee.TerminatedDate;

                    // Update properties of the associated person
                    existingEmployee.Person.LastName = employee.Person.LastName;
                    existingEmployee.Person.FirstName = employee.Person.FirstName;
                    existingEmployee.Person.BirthDate = employee.Person.BirthDate;

                    _employeeManagementContext.Update(existingEmployee);
                    _employeeManagementContext.SaveChanges();
                    transaction.Commit();

                    return existingEmployee;
                }
                else return new Employee();
            }
            catch (Exception exception)
            {
                transaction.Rollback();

                var errorMessage = $"[{source}]: Something went wrong while trying to update [{nameof(Employee)}] with Employee ID: [{employee.Id}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

    }
}
