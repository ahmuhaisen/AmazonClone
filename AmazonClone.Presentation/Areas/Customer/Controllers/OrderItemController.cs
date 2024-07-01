using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderItemController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderService orderService, IOrderItemService orderItemService, IMapper mapper)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _mapper = mapper;
        }


        public IActionResult Index(int orderId)
        {
            var order = _orderService.Get(orderId);
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
}
