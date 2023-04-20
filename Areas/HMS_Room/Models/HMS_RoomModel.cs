using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Areas.HMS_Room.Models
{
    public class HMS_RoomModel
    {
        public int RoomID { get; set; }

        public int RoomLocation { get; set; }

        public string RoomCost { get; set; }

        public string BedSize { get; set; }

        public IFormFile? File1 { get; set; }

        public string? RoomPhoto { get; set; }

        public string? Description { get; set; }
 

        public int RoomCategoryID { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
        public string CategoryName { get; set; }

        public int CheckAvailID { get; set; }


    }


}
