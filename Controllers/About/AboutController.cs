using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers.About
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View("about");
        }
    }
}
