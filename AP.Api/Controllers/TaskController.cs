using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskBusiness taskBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Data.Models.Task>> Get()
        {
            return (IEnumerable<Data.Models.Task>)await taskBusiness.GetTask(id: null);
        }
    }
}
