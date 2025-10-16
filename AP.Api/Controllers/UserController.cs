using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserBusiness userBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userBusiness.GetUser(id: null);
        }
    }
}
