using AP.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AP.Mvc.Controllers
{
    public class RepositoryController : Controller
    {
        private readonly IProductRepository _productRepository;

        public RepositoryController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }




        public IActionResult Index()
        {
            var allProducts = _productRepository.GetAllProducts().ToArray();
            return View(allProducts);
        }
    }
}
