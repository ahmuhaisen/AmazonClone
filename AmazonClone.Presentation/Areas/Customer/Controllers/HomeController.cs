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


        public IActionResult Index()
        {
            var model = new CustomerHomeViewModel
            {
                PopularCategories = _categoryService
                                                .GetMostPopular()
                                                .Select(x => new CustomerHomeCategoryViewModel { Id = x.Id, Name = x.Name, IconString = x.IconString })
                                                .ToList(),

                Products = _productService
                                                .GetAll()
                                                .Select(x => new CustomerHomeProductViewModel
                                                {
                                                    Id = x.Id,
                                                    ImageUrl = x.ImageUrl,
                                                    Name = x.Name.Length >= 25 ? $"{x.Name.Substring(0, 25)}.." : x.Name, 
                                                    CategoryName = x.Category.Name.ToUpper(),
                                                    DiscountPercentage = x.DiscountPercentage,
                                                    Price = x.Price
                                                })
                                                .ToList()
            };
            return View(model);
        }
    }
}
