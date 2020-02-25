using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum Role
    {
        Guest = 1,
        Host = 2,
        Admin = 3
    }

    public enum Type
    {
        Apartment = 1,
        Room = 2
    }

    public enum Status
    {
        Active = 1,
        Inactive = 2
    }
}