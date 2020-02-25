using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminController : ControllerBase
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult EditAdmin(Admin a)
        {
            if (!((Admin)Session["LogedAdmin"]).Username.Equals(a.Username))
            {
                getAdmins.Remove(((Admin)Session["LogedAdmin"]).Username);
            }

            a.Role = Role.Admin;
            getAdmins[a.Username] = a;
            Session["LogedAdmin"] = getAdmins[a.Username];
            PrintAdmins();

            return View("Index");

        }

        public ActionResult GoToAddHost()
        {
            return View("AddHost");
        }

        [HttpPost]
        public ActionResult AddHost(Host host)
        {
            if (getHosts.ContainsKey(host.Username))
            {
                return View("Edit"); //promeinitiiiiiiiiiiii!!!!!!!
            }
            else
            {
                getHosts.Add(host.Username, host);
            }

            PrintHosts();
            return View("Index");
        }

        public ActionResult ShowGuests()
        {
            ViewBag.guests = getGuests;
            return View("ShowGuests");
        }

        public ActionResult Logout()
        {
            Session["LogedAdmin"] = null;
            return RedirectToAction("Index", "Login");
        }

    }
}