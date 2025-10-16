using AP.Mvc.Models;
using AP.Mvc.ServiceLocator2;
using AP.ServiceLocator2.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AP.Mvc.Controllers
{
    public class RoleController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public RoleController(ILogger<UserController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _serviceLocator.GetDataRoleAsync();
            var roleViewModel = new RoleViewModel()
            {
                Role = roles
            };
            return View(roleViewModel);
        }
    }
}
