using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryBusiness categoryBusiness) : ControllerBase
    {
        // GET: api/<ProductApiController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await categoryBusiness.GetCategory(id: null);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var result = await categoryBusiness.CreateCategoryAsync(category);
            if (result)
                return Ok("Categoría guardada correctamente.");
            return BadRequest("No se pudo guardar la categoría.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put( [FromBody] Category category)
        {

            var result = await categoryBusiness.UpdateCategoryAsync(category);
            if (result)
                return Ok("Categoría actualizada correctamente.");
            return BadRequest("No se pudo actualizar la categoría.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryBusiness.DeleteCategoryAsync(id);
            if (result)
                return Ok("Categoría eliminada correctamente.");
            return NotFound("No se encontró la categoría para eliminar.");
        }



    }
}
