using WebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Text;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoToLogIn()
        {
            return View("LogIn");
        }

        public ActionResult GoToSignIn()
        {
            return View("Register");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        private void PrintUsers()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/guests.txt");

            foreach(KeyValuePair<string, Guest> kv in getGuests)
            {
                file.WriteLine(kv.Value.Username + ";" + kv.Value.Password + ";" + kv.Value.Name + ";" + kv.Value.Surname + ";" + kv.Value.Gender + ";" + kv.Value.Role);
            }
            file.Close();
        }

        private Dictionary<string, Guest> getGuests
        {
            get
            {
                return (Dictionary<string, Guest>)Session["Guests"];
            }
        }

        private Dictionary<string, Admin> getAdmins
        {
            get
            {
                return (Dictionary<string, Admin>)Session["Admins"];
            }
        }


        private Dictionary<string, Host> getHosts
        {
            get
            {
                return (Dictionary<string, Host>)Session["Hosts"];
            }
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (!getGuests.ContainsKey(username))
            {
                if (getAdmins.ContainsKey(username))
                {
                    if (!getAdmins[username].Password.Equals(password))
                    {
                        return View("PasswordError");
                    }

                    Session["LogedAdmin"] = getAdmins[username];
                    return RedirectToAction("Index", "Admin");
                }

                if (getHosts.ContainsKey(username))
                {
                    if (!getHosts[username].Password.Equals(password))
                    {
                        return View("PasswordError");
                    }

                    Session["LogedHost"] = getHosts[username];
                    return RedirectToAction("Index", "Host");
                }

                
                return View("NoUsername"); 
            }

            

            if (!getGuests[username].Password.Equals(password))
            {
                return View("PasswordError"); 
            }

            Session["LogedGuest"] = getGuests[username];

            return RedirectToAction("Index", "Guest");
        }

        [HttpPost]
        public ActionResult Register(Guest g)
        {
            g.Role = Role.Guest;
            if (getGuests.ContainsKey(g.Username))
            {
                ViewBag.Guest = g;
                return View("RegisterError");
            }
            else
            {
                getGuests.Add(g.Username, g);
            }
            PrintUsers();
            return View("Index");




            
        }

    }
}

            