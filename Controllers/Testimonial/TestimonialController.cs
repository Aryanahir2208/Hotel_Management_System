using Microsoft.AspNetCore.Mvc;
namespace Hotel_Management_System.Controllers.Testimonial
{
    public class TestimonialController : Controller
    {
        public IActionResult Index()
        {
            return View("testimonial");
        }

    }
}
