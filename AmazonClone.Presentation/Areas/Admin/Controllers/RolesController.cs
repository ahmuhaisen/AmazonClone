using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RolesConsts.ADMIN_USER)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(roles);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AdminRoleFormViewModel model)
        {
            // try remove it await'
            if (!ModelState.IsValid)
                return View("Index", await _roleManager.Roles.ToListAsync());

            var roleIsExists = await _roleManager.RoleExistsAsync(model.Name);

            if (roleIsExists)
            {
                ModelState.AddModelError("Name", "Role is exist");
                return View("Index", await _roleManager.Roles.ToListAsync());
            }


            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));

            return RedirectToAction(nameof(Index));
        }
    }
}
