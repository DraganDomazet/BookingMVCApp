using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Comment
    {
        public Guest Guest { get; set; }
        public Apartment Stan { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}