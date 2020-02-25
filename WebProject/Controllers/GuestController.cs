using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class GuestController : ControllerBase
    {
        // GET: Guest
        public ActionResult Index()
        {   
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

       
        public ActionResult Logout()
        {
            Session["LogedGuest"] = null;
           return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public ActionResult EditUser(Guest g)
        {
            if (!((Guest)Session["LogedGuest"]).Username.Equals(g.Username))
            {
                getGuests.Remove(((Guest)Session["LogedGuest"]).Username);
            }

            g.Role = Role.Guest;
            getGuests[g.Username] = g;
            Session["LogedGuest"] = getGuests[g.Username];
            PrintUsers();

            return View("Index");
        }
    }
}