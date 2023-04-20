using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers.Booking
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View("booking");
        }
       
    }
}
