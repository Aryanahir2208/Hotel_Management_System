using Hotel_Management_System.Areas.HMS_Room.Models;
using Hotel_Management_System.Areas.HMS_RoomCategory.Models;
using Hotel_Management_System.BAL;
using Hotel_Management_System.DAL;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hotel_Management_System.Areas.HMS_Room.Controllers
{
    [Area("HMS_Room")]
    [Route("HMS_Room/[action]")]
    public class HMS_RoomController : Controller
    {

        HMS_RoomDAL dalHMSRoom = new HMS_RoomDAL();


        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalHMSRoom.PR_HMS_Rooms_SelectAll();
            return View("RoomList", dt);
        }
        #endregion


        #region Delete
        public IActionResult Delete(int RoomID)
        {



            if (Convert.ToBoolean(dalHMSRoom.PR_HMS_Rooms_Delete(RoomID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        #endregion


        #region Add

        public IActionResult Add(int? RoomID)
        {
            #region DDL OF Room Category
            HMS_RoomDAL dalHMSRoom = new HMS_RoomDAL();
            DataTable dtRoomCat = dalHMSRoom.PR_HMS_RoomCategory_SelectComboBox();

            List<HMS_RoomCatDropDownModel> list = new List<HMS_RoomCatDropDownModel>();
            foreach (DataRow dr in dtRoomCat.Rows)
            {
                HMS_RoomCatDropDownModel vlst = new HMS_RoomCatDropDownModel();
                vlst.RoomCategoryID = Convert.ToInt32(dr["RoomCategoryID"]);
                vlst.CategoryName = dr["CategoryName"].ToString();
                list.Add(vlst);
            }
            ViewBag.RoomCategoryList = list;

            #endregion

            if (RoomID != null)
            {
                DataTable dtroom = dalHMSRoom.PR_HMS_Rooms_SelectByPK(RoomID);
                if (dtroom.Rows.Count > 0)
                {
                    HMS_RoomModel modelHMS_Room = new HMS_RoomModel();
                    foreach (DataRow dr in dtroom.Rows)
                    {
                        modelHMS_Room.RoomID = Convert.ToInt32(dr["RoomID"]);
                        modelHMS_Room.RoomLocation = Convert.ToInt32(dr["RoomLocation"]);
                        modelHMS_Room.RoomPhoto = dr["RoomPhoto"].ToString();
                        modelHMS_Room.Description = dr["Description"].ToString();
                        modelHMS_Room.RoomCategoryID = Convert.ToInt32(dr["RoomCategoryID"]);
                        modelHMS_Room.Created = Convert.ToDateTime(dr["Created"]);
                        modelHMS_Room.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                    return View("RoomAddEdit", modelHMS_Room);
                }
            }

            return View("RoomAddEdit");
        }
        #endregion


        #region Save
        [HttpPost]
        public IActionResult Save(HMS_RoomModel modelHMS_Room)
        {
            if (modelHMS_Room.File1 != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNamewithPath = Path.Combine(path, modelHMS_Room.File1.FileName);
                modelHMS_Room.RoomPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelHMS_Room.File1.FileName;

                using (var stream = new FileStream(fileNamewithPath, FileMode.Create))
                {
                    modelHMS_Room.File1.CopyTo(stream);
                }
            }

            if (modelHMS_Room.RoomID == null)
            {
                if (Convert.ToBoolean(dalHMSRoom.PR_HMS_Rooms_Insert(modelHMS_Room)))
                    TempData["AlertMsg"] = "Record Inserted Successfully";
            }
            else
            {
                if (Convert.ToBoolean(dalHMSRoom.PR_HMS_Rooms_Update(modelHMS_Room)))
                    TempData["AlertMsg"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion



    }

}

