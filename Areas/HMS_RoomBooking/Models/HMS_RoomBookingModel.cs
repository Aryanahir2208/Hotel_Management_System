using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Areas.HMS_RoomBooking.Models
{
    public class HMS_RoomBookingModel
    {
        public int RoomBookingID { get; set; }

        public int PrefixID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        public string PinCode { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }



    }
}
