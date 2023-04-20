using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Areas.HMS_CheckAvail.Models
{
    public class HMS_CheckAvailModel
    {
        public int CheckAvailID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalAdults { get; set; }

        public int TotalChilds { get; set; }


        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int? RoomID { get; set; }

        public int? RoomCategoryID { get; set; }


    }
}
