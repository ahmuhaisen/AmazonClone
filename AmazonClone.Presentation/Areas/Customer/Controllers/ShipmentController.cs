namespace AmazonClone.Presentation.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = RolesConsts.CUSTOMER_USER)]
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipmentController(IShipmentService shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(new CustomerShipmentFormViewModel());
        }


        [HttpPost]
        public IActionResult Create(CustomerShipmentFormViewModel model)
        {
            if(!ModelState.IsValid)
                return View(nameof(Index), model);

            var shipmentToCreate = _mapper.Map<Shipment>(model);

            _shipmentService.Create(shipmentToCreate);

            TempData["shipmentId"] = shipmentToCreate.Id;
            TempData["success"] = "Shipment created";

            
            return RedirectToAction("Index", "Payment");
        }
    }
}
