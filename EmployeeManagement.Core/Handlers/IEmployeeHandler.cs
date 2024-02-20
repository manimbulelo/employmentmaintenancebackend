using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Core.Handlers
{
    public interface IEmployeeHandler 
    {
        Employee CreateEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        void DeleteEmployee(int employeeId);

        List<Employee> GetAllEmployees();
    }
}
