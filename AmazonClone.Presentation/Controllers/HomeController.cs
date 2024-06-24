using AmazonClone.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmazonClone.Presentation.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
               
    }
}
