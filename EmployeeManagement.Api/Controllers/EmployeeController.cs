using EmployeeManagement.Api.Controllers.Base;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    public class EmployeeController : ApiControllerBase
    {
        [HttpPost]
        [Route(nameof(CreateEmployee))]
        [Produces(typeof(Employee))]
        public IActionResult CreateEmployee([FromServices] IEmployeeHandler handler, Employee employee)
        {
            var result = handler.CreateEmployee(employee);
            return Ok(result);
        }

        [HttpPost]
        [Route(nameof(UpdateEmployee))]
        [Produces(typeof(Employee))]
        public IActionResult UpdateEmployee([FromServices] IEmployeeHandler handler, Employee employee)
        {
            var result = handler.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpDelete]
        [Route(nameof(DeleteEmployee))]
        [Produces(typeof(Employee))]
        public IActionResult DeleteEmployee([FromServices] IEmployeeHandler handler, int employeeId)
        {
            handler.DeleteEmployee(employeeId);
            return Ok();
        }

        [HttpGet]
        [Route(nameof(GetAllEmployees))]
        [Produces(typeof(Employee))]
        public IActionResult GetAllEmployees([FromServices] IEmployeeHandler handler)
        {
            var results = handler.GetAllEmployees();
            return Ok(results);
        }
    }
}
