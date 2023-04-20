
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers.Service
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View("service");
        }
    }
}
