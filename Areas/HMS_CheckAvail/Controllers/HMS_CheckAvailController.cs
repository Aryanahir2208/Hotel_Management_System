using Microsoft.AspNetCore.Mvc;
using Hotel_Management_System.DAL;
using Microsoft.Data.SqlClient;
using System.Data;
using Hotel_Management_System.BAL;

namespace Hotel_Management_System.Areas.HMS_CheckAvail.Controllers
{
    
    [Area("HMS_CheckAvail")]
    [Route("HMS_CheckAvail/[action]")]
  
    public class HMS_CheckAvailController : Controller
    {
        HMS_CheckAvailDAL dalHMS_CheckAvail = new HMS_CheckAvailDAL();


        #region SelectAll
        public IActionResult Index()
        {

            DataTable dt = dalHMS_CheckAvail.PR_HMS_CheckAvail_SelectAll();
            return View("CheckAvailList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int RoomBookingID)
        {
            if (Convert.ToBoolean(dalHMS_CheckAvail.PR_HMS_CheckAvail_Delete(RoomBookingID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        #endregion

    }
}
