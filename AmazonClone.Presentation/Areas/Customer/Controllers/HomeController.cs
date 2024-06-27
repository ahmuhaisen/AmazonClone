using AmazonClone.Domain.ViewModels.Customer;

namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }


        public IActionResult Index(int? categoryId = null)
        {
            var model = new CustomerHomeViewModel
            {
                PopularCategories = _categoryService.GetMostPopular(),
                Products = _productService.GetHomeProductsList(categoryId)
            };
            return View(model);
        }
    }
}
