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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var result = await productBusiness.SaveProductAsync(product);
            if (result)
                return Ok("Producto guardado correctamente.");
            return BadRequest("No se pudo guardar el producto.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {

            var result = await productBusiness.SaveProductAsync(product);
            if (result)
                return Ok("Producto actualizado correctamente.");
            return BadRequest("No se pudo actualizar el producto.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productBusiness.DeleteProductAsync(id);
            if (result)
                return Ok("Producto eliminado correctamente");
            return NotFound("No se encontro el producto para eliminar.");
        }


    }
}
