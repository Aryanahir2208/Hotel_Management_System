using Hotel_Management_System.Areas.HMS_Room.Models;
using Hotel_Management_System.Areas.HMS_RoomCategory.Models;
using Hotel_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System.Areas.HMS_Room.Controllers
{
    [Area("CON_Contact")]
    [Route("CON_Contact/[action]")]
    public class CON_ContactController : Controller
    {

        CON_ContactDAL dalCON_Contact = new CON_ContactDAL();


        #region SelectAll
        public IActionResult Index()
        {

            DataTable dt = dalCON_Contact.PR_CON_Contact_SelectAll();
            return View("ContactList", dt);
        }
        #endregion


        #region Delete
        public IActionResult Delete(int ContactID)
        {
            if (Convert.ToBoolean(dalCON_Contact.PR_CON_Contact_Delete(ContactID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        #endregion


    }

}

