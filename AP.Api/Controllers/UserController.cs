using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserBusiness userBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userBusiness.GetUser(id: null);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var result = await userBusiness.SaveUserAsync(user);
            if (result)
                return Ok("User guardado correctamente.");
            return BadRequest("No se pudo guardar el user.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User user)
        {

            var result = await userBusiness.SaveUserAsync(user);
            if (result)
                return Ok("User actualizado correctamente.");
            return BadRequest("No se pudo User el producto.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userBusiness.DeleteUserAsync(id);
            if (result)
                return Ok("User eliminado correctamente");
            return NotFound("No se encontro el User para eliminar.");
        }
    }
}
