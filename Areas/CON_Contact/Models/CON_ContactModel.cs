using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Areas.CON_Contact.Models
{

    public class CON_ContactModel
    {
        public int? ContactID { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string? Message { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
