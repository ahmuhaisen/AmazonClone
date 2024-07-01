namespace AmazonClone.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesConsts.ADMIN_USER)]
    public class HomeController : Controller
    {

        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IProductService productService, IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _productService = productService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = new AdminHomeViewModel
            {
                NoOfProducts = _productService.GetNumberOfAvailableProducts(),
                NoOfUsers = _userManager.Users.Count(),
                NoOfOrders = _orderService.GetNoOfOrders(),
                SalesVolume = _orderService.GetSalesVolume()
            };


            return View(model);
        }
    }
}
