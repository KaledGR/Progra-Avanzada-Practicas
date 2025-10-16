using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleBusiness roleBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
            return await roleBusiness.GetRole(id: null);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            var result = await roleBusiness.SaveRoleAsync(role);
            if (result)
                return Ok("Rol guardado correctamente.");
            return BadRequest("No se pudo guardar el Rol.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Role role)
        {

            var result = await roleBusiness.SaveRoleAsync(role);
            if (result)
                return Ok("Rol actualizado correctamente.");
            return BadRequest("No se pudo actualizar el Rol.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await roleBusiness.DeleteRoleAsync(id);
            if (result)
                return Ok("Rol eliminado correctamente");
            return NotFound("No se encontro el Rol para eliminar.");
        }

    }
}
