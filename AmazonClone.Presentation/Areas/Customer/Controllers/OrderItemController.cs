namespace AmazonClone.Presentation.Areas.Customer.Controllers;

[Area("Customer")]
[Authorize(Roles = RolesConsts.CUSTOMER_USER)]
public class OrderItemController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IOrderItemService _orderItemService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public OrderItemController(IOrderService orderService, IOrderItemService orderItemService, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _orderService = orderService;
        _orderItemService = orderItemService;
        _mapper = mapper;
        _userManager = userManager;
    }


    public async Task<IActionResult> Index(int orderId)
    {
        var order = _orderService.Get(orderId);

        if (order.UserId != _userManager.GetUserAsync(User).Result!.Id)
            return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });

        var items = _orderItemService.GetAllBy(i => i.OrderId == orderId);


        var model = new CustomerOrderDetailsViewModel
        {
            CurrentOrder = _mapper.Map<CustomerOrderViewModel>(order),
            OrderItems = items.Select(x => new CustomerOrderItemViewModel
            {
                ImageUrl = x.Product.ImageUrl,
                Name = x.Product.Name,
                Price = x.Product.ActualPrice,
                Quantity = x.Quantity,
            })
        };
        return View(model);
    }
}
