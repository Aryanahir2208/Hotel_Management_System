using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Areas.Home.Controllers
{
    [Area("Home")]
    [Route("Home/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
