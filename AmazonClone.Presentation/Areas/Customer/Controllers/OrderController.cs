using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = RolesConsts.CUSTOMER_USER)]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _orderService = orderService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return NotFound();


            var userOrders = _orderService.GetAllBy(o => o.UserId == user.Id);

            //map
            var model = _mapper.Map<IEnumerable<CustomerOrderViewModel>>(userOrders);

            return View(model);
        }
    }
}
