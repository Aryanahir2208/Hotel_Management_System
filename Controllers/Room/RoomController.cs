using Hotel_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hotel_Management_System.Controllers.Room
{
    public class RoomController : Controller
    {
        HMS_RoomDAL dalHMSRoom = new HMS_RoomDAL();
        public IActionResult Index()
        {
            DataTable dt = dalHMSRoom.PR_HMS_Rooms_SelectAll();
            return View("room", dt);
        }

        
    }
}
