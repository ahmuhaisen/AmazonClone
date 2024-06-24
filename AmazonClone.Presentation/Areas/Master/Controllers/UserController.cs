namespace AmazonClone.Presentation.Areas.Master.Controllers
{
    [Area("Master")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userMangager;

        public UserController(UserManager<ApplicationUser> userMangager)
        {
            _userMangager = userMangager;
        }

        public async Task<IActionResult> Details(string userId)
        {

            var user = await _userMangager.GetUserAsync(User);

            // Try AutoMapper here!!
            var model = new UserDetailsViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserName = user.UserName,
                Roles = _userMangager.GetRolesAsync(user).Result.ToArray()
            };



            return View(model);
        }
    }
}
