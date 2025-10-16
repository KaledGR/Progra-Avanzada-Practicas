using AP.Mvc.Models;
using AP.Mvc.ServiceLocator2;
using AP.ServiceLocator2.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AP.Mvc.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public TaskController(ILogger<UserController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _serviceLocator.GetDataTaskAsync();
            var taskViewModel = new TaskViewModel()
            {
                Task = tasks
            };
            return View(taskViewModel);
        }
    }
}
