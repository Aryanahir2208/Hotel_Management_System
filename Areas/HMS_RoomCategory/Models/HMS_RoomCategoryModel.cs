using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Areas.HMS_RoomCategory.Models
{

    public class HMS_RoomCategoryModel
    {
        public int? RoomCategoryID { get; set; }

        public string CategoryName { get; set; }


        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
    public class HMS_RoomCatDropDownModel
    {
        public int RoomCategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
