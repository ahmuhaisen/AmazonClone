namespace AmazonClone.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesConsts.ADMIN_USER)]
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users
                .Select(x => new AdminUserViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    UserName = x.UserName,
                    Roles = _userManager.GetRolesAsync(x).Result
                })
                .ToListAsync().Result;


            return View(users);
        }
    }
}
