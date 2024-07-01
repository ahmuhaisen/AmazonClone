using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = RolesConsts.CUSTOMER_USER)]
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
            var wishlistProducts = _wishlistService.GetCustomerWishlistProducts(_userManager.GetUserAsync(User).Result!.Id);


            WishlistViewModel model = new() 
            { 
                Products = wishlistProducts.Select(_productService.ConvertProductToViewModel) 
            };
            
            return View(model);
        }

        
        [HttpPost]
        public async Task<JsonResult> AddToWishlist(int productId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null || productId is 0)
                return Json(new { success = false });

            if (_wishlistService.IsProductInCustomerWishlist(user.Id, productId))
                return Json(new { success = false, message = "Product is already in your wishlist" });

            _wishlistService.Add(new WishlistItem { ProductId = productId, UserId = user.Id });

            return Json(new { success = true, message = "Product added to your wishlist" });
        }


        [HttpPost]
        public async Task<JsonResult> RemoveFromWishlist(int productId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null || productId is 0)
                return Json(new { success = false });

            var wishlistItem = _wishlistService.Get(x => x.ProductId == productId && x.UserId == user.Id);
            if (wishlistItem is null)
                return Json(new { success = false, message = "Product is not in your wishlist" });

            _wishlistService.Remove(wishlistItem);

            return Json(new { success = true, message = "Product removed from your wishlist" });
        }

    }

}

