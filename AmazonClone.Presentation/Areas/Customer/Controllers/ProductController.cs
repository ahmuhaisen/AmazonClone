namespace AmazonClone.Presentation.Areas.Customer.Controllers;

[Area("Customer")]
[Authorize(Roles = RolesConsts.CUSTOMER_USER)]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }


    public IActionResult Details(int id)
    {
        if (id == 0)
            return NotFound();

        var productToDisplay = _productService.Get(x => x.Id == id);

        if (productToDisplay is not null)
        {
            var model = _mapper.Map<CustomerDetailsProductViewModel>(productToDisplay);
            return View(model);
        }

        return RedirectToAction(nameof(HomeController.Index));
    }
}
