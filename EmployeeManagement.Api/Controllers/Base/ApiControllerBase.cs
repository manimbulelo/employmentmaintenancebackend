using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
