using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;


namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController(IComponentBusiness componentBusiness) : ControllerBase
    {
        // GET: api/<ProductApiController>
        [HttpGet]
        public async Task<IEnumerable<Component>> Get()
        {
            return await componentBusiness.GetComponent(id: null);
        }
    }
}
