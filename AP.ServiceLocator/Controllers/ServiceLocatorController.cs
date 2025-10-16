
using AP.Models.DTOs;
using AP.ServiceLocator.Helper;
using AP.ServiceLocator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AP.ServiceLocator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceLocatorController : ControllerBase
    {


        private readonly ICategoryService _categoryService;
        private readonly IComponentService _componentService;
        private readonly IInventorService _inventorService;
        private readonly IProductService _productService;
        private readonly IRoleService _roleService;
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public ServiceLocatorController(ICategoryService categoryService, IComponentService componentService, IInventorService inventorService, 
            IProductService productService, IRoleService roleService, ITaskService taskService, IUserService userService)
        { 
            _categoryService = categoryService;
            _componentService = componentService;
            _roleService = roleService;
            _taskService = taskService;
            _userService = userService;
            _productService = productService;
            _inventorService = inventorService;
        }

        // GET api/<ServiceLocatorController>/5
      

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategory()
        {
            return await _categoryService.GetDataAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<ComponentDTO>> GetComponent()
        {
            return await _componentService.GetDataAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<RoleDTO>> GetRole()
        {
            return await _roleService.GetDataAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDTO>> GetTask()
        {
            return await _taskService.GetDataAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUser()
        {
            return await _userService.GetDataAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetProduct()
        {
            return await _productService.GetDataAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<InventoryDTO>> GetInventor()
        {
            return await _inventorService.GetDataAsync();
        }



    }
}
