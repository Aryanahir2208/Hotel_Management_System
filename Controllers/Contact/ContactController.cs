using Hotel_Management_System.Areas.CON_Contact.Models;
using Hotel_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hotel_Management_System.Controllers.Contact
{
    public class ContactController : Controller
    {
        CON_ContactDAL dalCON_Contact = new CON_ContactDAL();
        public IActionResult Index()
        {
            return View("contact");
        }

        #region Save
        [HttpPost]
        public IActionResult Save(CON_ContactModel modelCON_Contact)
        {

            if (modelCON_Contact.ContactID == null)
            {
                if (Convert.ToBoolean(dalCON_Contact.PR_CON_Contact_Insert(modelCON_Contact)))
                    TempData["AlertMsg"] = "Record Inserted Successfully";
            }
           
            return RedirectToAction("Index");
        }
        #endregion
    }
}
