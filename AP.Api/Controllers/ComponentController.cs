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


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Component component)
        {
            var result = await componentBusiness.SaveComponentAsync(component);
            if (result)
                return Ok("Componente guardado correctamente.");
            return BadRequest("No se pudo guardar la categoría.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Component component)
        {

            var result = await componentBusiness.SaveComponentAsync(component);
            if (result)
                return Ok("Componente actualizado correctamente.");
            return BadRequest("No se pudo actualizar el Componente.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await componentBusiness.DeleteComponentAsync(id);
            if (result)
                return Ok("Componente eliminado correctamente.");
            return NotFound("No se encontro el componente para eliminar.");
        }

    }
}
