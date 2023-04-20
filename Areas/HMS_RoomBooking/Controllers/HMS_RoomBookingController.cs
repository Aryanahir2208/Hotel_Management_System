using Microsoft.AspNetCore.Mvc;
using Hotel_Management_System.DAL;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System.Areas.HMS_RoomBooking.Controllers
{
    [Area("HMS_RoomBooking")]
    [Route("HMS_RoomBooking/[action]")]
    public class HMS_RoomBookingController : Controller
    {
        HMS_RoomBookingDAL dalHMS_RoomBooking = new HMS_RoomBookingDAL();


        #region SelectAll
        public IActionResult Index()
        {

            DataTable dt = dalHMS_RoomBooking.PR_HMS_RoomBooking_SelectAll();
            return View("RoomBookingList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int RoomBookingID)
        {
            if (Convert.ToBoolean(dalHMS_RoomBooking.PR_HMS_RoomBooking_Delete(RoomBookingID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        #endregion


    }
}
