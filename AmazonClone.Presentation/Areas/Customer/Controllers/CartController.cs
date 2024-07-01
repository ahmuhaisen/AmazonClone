namespace AmazonClone.Presentation.Areas.Customer.Controllers;


[Area("Customer")]
[Authorize(Roles = RolesConsts.CUSTOMER_USER)]
public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly ICheckoutService _checkoutService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartController(ICartService cartService, ICheckoutService checkoutService, UserManager<ApplicationUser> userManager)
    {
        _cartService = cartService;
        _checkoutService = checkoutService;
        _userManager = userManager;
    }



    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        var userCartItems = _cartService.GetCustomerCartItems(user.Id);

        if (!userCartItems.Any())
            return View(new CustomerCartViewModel());

        var checkoutData = _checkoutService.CalculateCheckout(userCartItems);


        CustomerCartViewModel model = new()
        {
            CartItems = _cartService.GetCustomerCartItemsAsModel(userCartItems),
            CheckoutSection = _checkoutService.GetCheckoutSection(checkoutData)
        };

        
        return View(model);
    }


    #region APIs
    [HttpPost]
    public async Task<JsonResult> AddToCart(int productId)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user is null || productId is 0)
            return Json(new { success = false });

        if (_cartService.IsProductInCustomerCart(user.Id, productId))
            return Json(new { success = false, message = "Product is already in your cart" });

        _cartService.Add(new CartItem { ProductId = productId, UserId = user.Id, Quantity = 1 });

        return Json(new { success = true, message = "Product added to your cart" });
    }

    [HttpPost]
    public async Task<JsonResult> RemoveFromCart(int productId)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user is null || productId is 0)
            return Json(new { success = false });

        if (!_cartService.IsProductInCustomerCart(user.Id, productId))
            return Json(new { success = false, message = "Product is not in your cart" });

        var itemToDelete = _cartService.Get(x => x.ProductId == productId && x.UserId == user.Id);
        _cartService.Remove(itemToDelete);

        return Json(new { success = true, message = "Product removed from your cart" });
    }

    [HttpPost]
    public async Task<JsonResult> UpdateProductQuantity(int productId, int newQuantity)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user is null || productId is 0 || newQuantity <= 0 || newQuantity > 100) 
            return Json(new { success = false });

        if (!_cartService.IsProductInCustomerCart(user.Id, productId))
            return Json(new { success = false, message = "Product is not in your cart" });

        var itemToUpdate = _cartService.Get(x => x.ProductId == productId && x.UserId == user.Id);
        itemToUpdate.Quantity = newQuantity;
        _cartService.Update(itemToUpdate);

        return Json(new { success = true, message = "Product's quantity updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetUpdatedCheckoutSection()
    {
        var user = await _userManager.GetUserAsync(User);

        var userCartItems = _cartService.GetCustomerCartItems(user.Id);

        if (!userCartItems.Any())
            return PartialView("_EmptyCartMessage");

        var checkoutData = _checkoutService.CalculateCheckout(userCartItems);

        CustomerCartViewModel model = new()
        {
            CartItems = _cartService.GetCustomerCartItemsAsModel(userCartItems),
            CheckoutSection = _checkoutService.GetCheckoutSection(checkoutData)
        };

        return PartialView("_CheckoutSection", model.CheckoutSection);
    }
    #endregion
}
