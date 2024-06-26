using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistController(IWishlistService wishlistService, UserManager<ApplicationUser> userManager, IProductService productService)
        {
            _wishlistService = wishlistService;
            _userManager = userManager;
            _productService = productService;
        }

        
        public async Task<IActionResult> Index()
        {
            var wishlistItems = _wishlistService.GetCustomerWishlist(_userManager.GetUserAsync(User).Result.Id);


            WishlistViewModel model = new WishlistViewModel
            {
                Products = wishlistItems.Select(p => new CustomerHomeProductViewModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name.Length >= 25 ? $"{p.Name.Substring(0, 25)}.." : p.Name,
                    CategoryName = p.Category.Name.ToUpper(),
                    DiscountPercentage = p.DiscountPercentage,
                    Price = p.Price
                })
            };
            return View(model);
        }
    }
}
