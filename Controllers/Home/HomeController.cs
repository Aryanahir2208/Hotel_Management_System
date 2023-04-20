using Hotel_Management_System.Areas.HMS_CheckAvail.Models;
using Hotel_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
namespace Hotel_Management_System.Controllers.Home

{
    public class HomeController : Controller
    {
        HMS_CheckAvailDAL dalHMS_CheckAvail = new HMS_CheckAvailDAL();
        public IActionResult Index()
        {
            return View("Index");
        }

        #region Save
      
        public IActionResult Save(HMS_CheckAvailModel modelHMS_CheckAvail)
        {

            if (modelHMS_CheckAvail.CheckAvailID == null)
            {
                if (Convert.ToBoolean(dalHMS_CheckAvail.PR_HMS_CheckAvail_Insert(modelHMS_CheckAvail, modelHMS_CheckAvail.RoomID)))
                    TempData["AlertMsg"] = "Record Inserted Successfully";
            }

            return RedirectToAction("Index");
        }
        #endregion

    }
}
