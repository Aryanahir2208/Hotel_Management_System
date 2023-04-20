using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers.Team
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View("team");
        }
    }
}
