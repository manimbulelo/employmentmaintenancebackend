using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Persistence.Managers
{
    public interface IEmployeeManager
    {
        Employee AddEmployee(Employee employee);
        
        Employee UpdateEmployee(Employee employee);

        void RemoveEmployee(int employeeId);
        
        List<Employee> GetAllEmployees();
    }
}
