using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    [Serializable]
    public class Apartment
    {
        public string Name { get; set; }            //treba!!
        public Type Type { get; set; }           //treba!!!!
        public int RoomNumber { get; set; }      //treba!!!
        public string GuestNumber { get; set; }     //treba!!!
        public Location Location { get; set; }   //treba!!!
        public DateTime Date { get; set; }
        public Host host { get; set; }
        public Comment Comment { get; set; }
        public List<string> Pictures { get; set; }      //treba!!!//treba!!!//treba!!!
        public int Price { get; set; }           //treba!!!
        public int CheckInTime { get; set; }
        public int CheckOutTime { get; set; }
        public Status Status { get; set; }
        public List<Amenities> ListAmenities { get; set; }





    }
}