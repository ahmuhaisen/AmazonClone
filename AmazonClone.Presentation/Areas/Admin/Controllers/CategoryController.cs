namespace AmazonClone.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesConsts.ADMIN_USER)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var allDbCategories = _categoryService.GetAll();

            var result = _mapper.Map<IEnumerable<AdminCategoryViewModel>>(allDbCategories);

            return View(result);
        }


        public IActionResult Upsert(int? id)
        {
            // Create
            if (id is null or 0)
                return View(new AdminCategoryViewModel());

            //Update
            var dbCategory = _categoryService.Get(x => x.Id == id);
            var model = _mapper.Map<AdminCategoryViewModel>(dbCategory);
            return View(model);
        }



        [HttpPost]
        public IActionResult Upsert(AdminCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var category = _mapper.Map<Category>(model);

            if (category.Id == 0)
            {
                _categoryService.Create(category);
                TempData["success"] = "Category created successfully";
            }
            else
            {
                _categoryService.Update(category);
                TempData["success"] = "Category updated successfully";
            }

            return RedirectToAction("Index");
        }
    }
}

