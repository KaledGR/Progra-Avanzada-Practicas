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


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inventory inventory)
        {
            var result = await inventoryBusiness.SaveInventoryAsync(inventory);
            if (result)
                return Ok("Inventorio guardado correctamente.");
            return BadRequest("No se pudo guardar la categoría.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Inventory inventory)
        {

            var result = await inventoryBusiness.SaveInventoryAsync(inventory);
            if (result)
                return Ok("Inventario actualizado correctamente.");
            return BadRequest("No se pudo actualizar el inventario.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await inventoryBusiness.DeleteInventoryAsync(id);
            if (result)
                return Ok("Inventario eliminado correctamente.");
            return NotFound("No se encontro el inventario para eliminar.");
        }


    }
}
