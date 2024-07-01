namespace AmazonClone.Presentation.Areas.Master.Controllers
{
    [Area("Master")]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}
