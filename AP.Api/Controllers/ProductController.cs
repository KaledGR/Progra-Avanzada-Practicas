using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductBusiness productBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productBusiness.GetProduct(id: null);
        }
    }
}
