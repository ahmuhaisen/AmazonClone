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

            var result = _mapper.Map<IEnumerable<CategoryDto>>(allDbCategories);

            return View(result);
        }


        public IActionResult Upsert(int? id)
        {
            if (id is null || id == 0)
            {
                // Create
                return View(new CategoryDto(0, "", "", false));

            }
            else
            {
                //Update

                var dbCategory = _categoryService.Get(x => x.Id == id);

                var categoryDto = _mapper.Map<CategoryDto>(dbCategory);

                return View(categoryDto);
            }
        }


        [HttpPost]
        public IActionResult Upsert(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            if(category.Id == 0)
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
