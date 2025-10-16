using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleBusiness roleBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
            return await roleBusiness.GetRole(id: null);
        }
    }
}
