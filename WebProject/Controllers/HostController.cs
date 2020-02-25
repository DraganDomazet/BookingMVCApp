using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using System.Xml;
using System.Xml.Serialization;

namespace WebProject.Controllers
{
    public class HostController : ControllerBase
    {
        // GET: Host
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult AddApartment()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditHost(Host host)
        {
            if (!((Host)Session["LogedHost"]).Username.Equals(host.Username))
            {
                getHosts.Remove(((Host)Session["LogedHost"]).Username);
            }
            host.Role = Role.Host;   
            getHosts[host.Username] = host;
            Session["LogedHost"] = getHosts[host.Username];
            PrintHosts();

            return View("Index");

        }


        public ActionResult Logout()
        {
            Session["LogedHost"] = null;
            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public ActionResult AddApp(string Name, Models.Type Type, int RoomNumber, int GuestNumber, Location l, Address adr, int Price)
        {

            l.address = adr;
            Apartment apart = new Apartment();
            apart.Name = Name;
            apart.Type = Type;
            apart.RoomNumber = RoomNumber;

            Dictionary<string, Apartment> probni = new Dictionary<string, Apartment>();
            probni.Add(apart.Name, apart);

           

              System.IO.StreamWriter file = new System.IO.StreamWriter("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/apartments.txt");

              foreach (KeyValuePair<string, Apartment> kv in probni)
              {
                  file.WriteLine(kv.Value.Name + ";" + kv.Value.Type + ";" + kv.Value.RoomNumber + ";" + "|" + "Amenitie1" + ";" + "Amenitie2" + "|");
              }
              file.Close();



            /* List<string> list = (List<string>)Session["UploadedFiles"]; enctype="multipart/form-data"
             if(list == null)
             {
                 list = new List<string>();
                 Session["UploadedFiles"] = list;
             }



             if(Request.Files.Count > 0)
             {
                 for(int i = 0; i < Request.Files.Count; i++)
                 {
                     var file = Request.Files[i];


                     if(file != null && file.ContentLength > 0)
                     {
                         var fileName = Path.GetFileName(file.FileName);
                         var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                         file.SaveAs(path);
                         list.Add(fileName);
                     }
                 }
             }*/
            // ViewBag.files = list;
            return View("Index");
        }


    }
}