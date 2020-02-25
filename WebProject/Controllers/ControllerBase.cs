using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;


namespace WebProject.Controllers
{
    public class ControllerBase : Controller
    {
        public Dictionary<string, Guest> getGuests
        {
            get
            {
                return (Dictionary<string, Guest>)Session["Guests"];
            }
        }


        public Dictionary<string, Admin> getAdmins
        {
            get
            {
                return (Dictionary<string, Admin>)Session["Admins"];
            }
        }


        public Dictionary<string, Host> getHosts
        {
            get
            {
                return (Dictionary<string, Host>)Session["Hosts"];
            }
        }


        public void PrintUsers()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/guests.txt");

            foreach (KeyValuePair<string, Guest> kv in getGuests)
            {
                file.WriteLine(kv.Value.Username + ";" + kv.Value.Password + ";" + kv.Value.Name + ";" + kv.Value.Surname + ";" + kv.Value.Gender + ";" + kv.Value.Role);
            }
            file.Close();
        }

        public void PrintAdmins()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/admins.txt");

            foreach (KeyValuePair<string, Admin> kv in getAdmins)
            {
                file.WriteLine(kv.Value.Username + ";" + kv.Value.Password + ";" + kv.Value.Name + ";" + kv.Value.Surname + ";" + kv.Value.Gender + ";" + kv.Value.Role);
            }
            file.Close();
        }

        public void PrintHosts()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/hosts.txt");

            foreach (KeyValuePair<string, Host> kv in getHosts)
            {
                file.WriteLine(kv.Value.Username + ";" + kv.Value.Password + ";" + kv.Value.Name + ";" + kv.Value.Surname + ";" + kv.Value.Gender + ";" + kv.Value.Role);
            }
            file.Close();
        }


    }
}