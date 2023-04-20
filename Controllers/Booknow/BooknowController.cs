
using Hotel_Management_System.Areas.HMS_CheckAvail.Models;
using Hotel_Management_System.Areas.HMS_Room.Models;
using Hotel_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Data;
using System.Runtime.InteropServices;

namespace Hotel_Management_System.Controllers.Booknow
{
    public class BooknowController : Controller
    {

        HMS_CheckAvailDAL dalHMS_CheckAvail = new HMS_CheckAvailDAL();
        HMS_RoomDAL dalHMS_Room = new HMS_RoomDAL();

        public IActionResult Index(HMS_RoomModel modelHMS_Room)
        {
            DataTable dt = dalHMS_Room.PR_HMS_Rooms_SelectByPK(modelHMS_Room.RoomCategoryID);
            TempData["RoomCategoryID"] = modelHMS_Room.RoomCategoryID;
            TempData["RoomID"] = modelHMS_Room.RoomID;



            return View();
        }

        public IActionResult SelectCheckAvailID(HMS_CheckAvailModel modelHMS_CheckAvail)
        {

            DataTable dt = dalHMS_CheckAvail.SelectCheckAvailID(modelHMS_CheckAvail);
            List<HMS_CheckAvailModel> list = new List<HMS_CheckAvailModel>();
            foreach (DataRow dr in dt.Rows)
            {
                HMS_CheckAvailModel vlst = new HMS_CheckAvailModel();
                vlst.CheckAvailID = Convert.ToInt32(dr["CheckAvailID"]);
                TempData["CheckAvailID"] = vlst.CheckAvailID;
                list.Add(vlst);
            }

            return RedirectToAction("Room", TempData["CheckAvailID"]);
        }

        public IActionResult Room()
        {

            DataTable dt = dalHMS_CheckAvail.PR_HMS_CheckAvail_SelectAllData(Convert.ToInt32(TempData["CheckAvailID"]));
            return View("_book",dt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(HMS_CheckAvailModel modelHMS_CheckAvail)
        {

            if (Convert.ToBoolean(dalHMS_CheckAvail.PR_HMS_CheckAvail_Insert(modelHMS_CheckAvail, Convert.ToInt32(TempData["RoomCategoryID"]))))

              


            TempData["AlertMsg"] = "Record Inserted Successfully";
            
            return RedirectToAction("SelectCheckAvailID");
        }

        public IActionResult tmp()
        {
            TempData["AlertMsg1"] = "Room Booked Sussessfully";
            return View("_book");
        }

    }
}
