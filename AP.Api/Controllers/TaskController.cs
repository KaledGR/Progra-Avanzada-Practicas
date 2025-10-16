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
            return await taskBusiness.GetTask(id: null);
        }
      

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Data.Models.Task task)
        {
            var result = await taskBusiness.SaveTaskAsync(task);
            if (result)
                return Ok("Task guardado correctamente.");
            return BadRequest("No se pudo guardar el Task.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Data.Models.Task task)
        {

            var result = await taskBusiness.SaveTaskAsync(task);
            if (result)
                return Ok("Task actualizado correctamente.");
            return BadRequest("No se pudo actualizar el Task.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await taskBusiness.DeleteTaskAsync(id);
            if (result)
                return Ok("Task eliminado correctamente");
            return NotFound("No se encontro el Task para eliminar.");
        }
    }
}
