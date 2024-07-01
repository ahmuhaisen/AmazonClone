using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ICheckoutService _checkoutService;
        private readonly UserManager<ApplicationUser> _userManager;


        public PaymentController(IPaymentService paymentService, IOrderService orderService,
            ICheckoutService checkoutService, UserManager<ApplicationUser> userManager)
        {
            _paymentService = paymentService;
            _orderService = orderService;
            _checkoutService = checkoutService;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var model = new CustomerPaymentFormViewModel
            {
                ShipmentId = (int)TempData["shipmentId"],
                TotalAmount = _checkoutService.GetCartTotalAmount()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerPaymentFormViewModel model)
        {
            
            if(!ModelState.IsValid) 
                return View(model);

            if (model.ShipmentId == 0)
                return RedirectToAction("Index", "Cart");

            var paymentToAdd = new Payment
            {
                PaymentMethod = model.SelectedPaymentMethod,
                Amount = model.TotalAmount,
                CreatedAt = DateTime.Now,
            };

            _paymentService.Create(paymentToAdd);

            if (paymentToAdd.Id != 0)
                TempData["success"] = "Payment created";

            var user = await _userManager.GetUserAsync(User);


            _orderService.MakeOrder(model.ShipmentId, paymentToAdd.Id, user.Id);

            return RedirectToAction("Index", "Order");
        }
    }



}
