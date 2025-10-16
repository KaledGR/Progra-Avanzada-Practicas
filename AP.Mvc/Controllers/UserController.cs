using AP.Mvc.Models;
using AP.Mvc.ServiceLocator2;
using AP.ServiceLocator2.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AP.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public UserController(ILogger<UserController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _serviceLocator.GetDataUserkAsync();
            var userViewModel = new UserViewModel()
            {
                User = users
            };
            return View(userViewModel);
        }

        
    }
}
