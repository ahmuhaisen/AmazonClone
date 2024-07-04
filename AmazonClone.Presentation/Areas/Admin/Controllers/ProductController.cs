namespace AmazonClone.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesConsts.ADMIN_USER)]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
            ICategoryService categoryService,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }


        public IActionResult Index(int? categoryId = null)
        {
            if(categoryId is not null or 0)
                TempData["SearchDefaultValueForProductsList"] = _categoryService.Get(x => x.Id == categoryId).Name;

            return View();
        }

        public IActionResult Upsert(int? id = null)
        {
            if (id is null or 0)
            {
                // Create View
                var upsertProductVM = new AdminUpsertProductViewModel()
                {
                    CategoryList = _categoryService.GetCategoriesAsListItems()
                };
                return View(upsertProductVM);

            }
            else
            {
                //Update View
                var productToUpdate = _productService.Get(x => x.Id == id);
                var upsertProductVM = new AdminUpsertProductViewModel();
                upsertProductVM = _mapper.Map<AdminUpsertProductViewModel>(productToUpdate);

                upsertProductVM.CategoryList = _categoryService.GetCategoriesAsListItems();

                return View(upsertProductVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(AdminUpsertProductViewModel upsertProductVM)
        {
            if (upsertProductVM.Id == 0 && upsertProductVM.Image is null)
                ModelState.AddModelError("Image", "Image field is required");

            if (upsertProductVM.Id != 0 && upsertProductVM.ImageUrl is null)
                ModelState.AddModelError("Image", "Image field is required");

            if (ModelState.IsValid)
            {
                var productToUpsert = _mapper.Map<Product>(upsertProductVM);

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (upsertProductVM.Image is not null)
                {
                    productToUpsert.ImageUrl = _productService.UpsertProductImage(productToUpsert.ImageUrl, upsertProductVM.Image, wwwRootPath);
                }


                if (upsertProductVM.Id == 0)
                    _productService.Create(productToUpsert);
                else
                    _productService.Update(productToUpsert);

                TempData["Success"] = "Product saved successfully";

                return RedirectToAction("Index");
            }
            else
            {
                upsertProductVM.CategoryList = _categoryService.GetCategoriesAsListItems();
                return View(upsertProductVM);
            }
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
                return NotFound();

            var productToDisplay = _productService.Get(x => x.Id == id);

            if (productToDisplay != null)
            {
                AdminDetailsProductViewModel AdminDetailsProductViewModel = new();
                AdminDetailsProductViewModel = _mapper.Map<AdminDetailsProductViewModel>(productToDisplay);
                return View(AdminDetailsProductViewModel);
            }

            return RedirectToAction("Index");
        }



        #region APIs
        public IActionResult Delete(int? id)
        {
            var productToDelete = _productService.Get(x => x.Id == id);
            if (productToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToDelete.ImageUrl.Trim('\\'));

            if (System.IO.File.Exists(oldImagePath))
                System.IO.File.Delete(oldImagePath);

            _productService.Remove(productToDelete);

            return Json(new { success = true, message = "Product deleted successfully" });
        }

        [HttpGet]
        public IActionResult IndexDataTable()
        {

            var products = _productService.GetAll();
            var totalRecords = products.Count();

            var jsonData = new {
                searchDefValue = TempData["SearchDefaultValueForProductsList"] is not null ? TempData["SearchDefaultValueForProductsList"] : "",
                recordsFiltered = totalRecords,
                totalRecords,
                data = products
            };
            
            return Ok((jsonData));
        }
        #endregion

    }
}
