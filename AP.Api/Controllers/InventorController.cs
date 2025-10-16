using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventorController(IInventoryBusiness inventoryBusiness) : ControllerBase
    {
        // GET: api/<ProductApiController>
        [HttpGet]
        public async Task<IEnumerable<Inventory>> Get()
        {
            return await inventoryBusiness.GetInventory(id: null);
        }
    }
}
