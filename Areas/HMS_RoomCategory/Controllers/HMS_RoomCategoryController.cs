using Hotel_Management_System.Areas.HMS_Room.Models;
using Hotel_Management_System.Areas.HMS_RoomCategory.Models;
using Hotel_Management_System.DAL;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System.Areas.HMS_RoomCategory.Controllers
{
    [Area("HMS_RoomCategory")]
    [Route("HMS_RoomCategory/[action]")]
    public class HMS_RoomCategoryController : Controller
    {
        HMS_RoomCategoryDAL dalHMSRoomCategory = new HMS_RoomCategoryDAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalHMSRoomCategory.PR_HMS_RoomCategory_SelectAll();
            return View("RoomCategoryList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int RoomCategoryID)
        {

            if (Convert.ToBoolean(dalHMSRoomCategory.PR_HMS_RoomCategory_Delete(RoomCategoryID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        #endregion

        #region Add

        public IActionResult Add(int? RoomCategoryID)
        {
           

            if (RoomCategoryID != null)
            {

                DataTable dtroomcat = dalHMSRoomCategory.PR_HMS_RoomCategory_SelectByPK(RoomCategoryID);
                if (dtroomcat.Rows.Count > 0)
                {
                    HMS_RoomCategoryModel modelHMS_RoomCategory = new HMS_RoomCategoryModel();
                    foreach (DataRow dr in dtroomcat.Rows)
                    {
                        modelHMS_RoomCategory.RoomCategoryID = Convert.ToInt32(dr["RoomCategoryID"]);
                        modelHMS_RoomCategory.CategoryName = dr["CategoryName"].ToString();
                        modelHMS_RoomCategory.Description = dr["Description"].ToString();
                        modelHMS_RoomCategory.Created = Convert.ToDateTime(dr["Created"]);
                        modelHMS_RoomCategory.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                    return View("RoomCategoryAddEdit", modelHMS_RoomCategory);
                }
            }

            return View("RoomCategoryAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(HMS_RoomCategoryModel modelHMS_RoomCategory)
        {

            if (modelHMS_RoomCategory.RoomCategoryID == null)
            {
                if (Convert.ToBoolean(dalHMSRoomCategory.PR_HMS_RoomCategory_Insert(modelHMS_RoomCategory)))
                    TempData["AlertMsg"] = "Record Inserted Successfully";
            }
            else
            {
                if (Convert.ToBoolean(dalHMSRoomCategory.PR_HMS_RoomCategory_Update(modelHMS_RoomCategory)))
                    TempData["AlertMsg"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
