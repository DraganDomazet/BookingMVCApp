using WebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;

namespace WebProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);       
        }


        protected void Session_Start()
        {
            string admin;
            Dictionary<string, Admin> admins = new Dictionary<string, Admin>();
            if (!File.Exists("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/admins.txt"))
            {
                File.Create("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/admins.txt");
            }

            StreamReader sr = new StreamReader("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/admins.txt");
            while((admin = sr.ReadLine()) != null)
            {
                Admin a = new Admin();
                a.Username = admin.Split(';')[0];
                a.Password = admin.Split(';')[1];
                a.Name = admin.Split(';')[2];
                a.Surname = admin.Split(';')[3];
                if (admin.Split(';')[4].Equals("Male"))
                {
                    a.Gender = Gender.Male;
                }
                else
                {
                    a.Gender = Gender.Female;
                }
                a.Role = Role.Admin;
                admins.Add(a.Username, a);

            }

            HttpContext.Current.Session["Admins"] = admins;
            sr.Close();


            Dictionary<string, Host> hosts = new Dictionary<string, Host>();
            string host;
            if(!File.Exists("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/hosts.txt"))
            {
                File.Create("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/hosts.txt");
            }
            StreamReader sh = new StreamReader("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/hosts.txt");
            while((host = sh.ReadLine()) != null){
                Host h = new Host();
                h.Username = host.Split(';')[0];
                h.Password = host.Split(';')[1];
                h.Name = host.Split(';')[2];
                h.Surname = host.Split(';')[3];
                if (host.Split(';')[4].Equals("Male"))
                {
                    h.Gender = Gender.Male;
                }
                else
                {
                    h.Gender = Gender.Female;
                }
                h.Role = Role.Guest;
                hosts.Add(h.Username, h);
            }

            HttpContext.Current.Session["Hosts"] = hosts;
            sh.Close();



            Dictionary<string, Guest> guests = new Dictionary<string, Guest>();
            if(!File.Exists("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/guests.txt")) {
                File.Create("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/guests.txt");
            }
            string user;
            StreamReader file = new StreamReader("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/guests.txt");
            while ((user = file.ReadLine()) != null)
            {
                Guest guest = new Guest();
                guest.Username = user.Split(';')[0];
                guest.Password = user.Split(';')[1];
                guest.Name = user.Split(';')[2];
                guest.Surname = user.Split(';')[3];
                if (user.Split(';')[4].Equals("Male"))
                {
                    guest.Gender = Gender.Male;
                }
                else
                {
                    guest.Gender = Gender.Female;
                }
                guest.Role = Role.Guest;
                guests.Add(guest.Username, guest);
            }
            file.Close();
            HttpContext.Current.Session["Guests"] = guests;


            Dictionary<string, Apartment> apartments = new Dictionary<string, Apartment>();
            if (!File.Exists("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/apartments.txt"))
            {
                File.Create("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/apartments.txt");
            }

            string app;
            StreamReader sa = new StreamReader("D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/apartments.txt");
            while ((app = sa.ReadLine()) != null)
             {
                string amenitie;
                 Apartment apart = new Apartment();
                apart.Name = app.Split(';')[0];
                if(app.Split(';')[1].Equals("Apartment")) {
                    apart.Type = Models.Type.Apartment;
                }
                else
                {
                    apart.Type = Models.Type.Room;
                }
                apart.RoomNumber =Int32.Parse(app.Split(';')[2]);
                amenitie = app.Split('|')[1];
                int br;
                br = amenitie.Split(';').Count();

             }
            sa.Close();

            //---------------amenities citanje
            string am;
            string am_path = "D:/FAKS/WEB1_Project/WebProject/WebProject/App_Data/amenities.txt";
            Dictionary<int, Amenities> amenities = new Dictionary<int, Amenities>();
            if (!File.Exists(am_path))
            {
                File.Create(am_path);
            }

            StreamReader sam = new StreamReader(am_path);
            while ((am = sam.ReadLine()) != null)
            {
                Amenities amen = new Amenities();
                amen.Id = Int32.Parse(am.Split(';')[0]);
                amen.Name = am.Split(';')[1];
                
                amenities.Add(amen.Id, amen);

            }

            HttpContext.Current.Session["Amenities"] = amenities;
            sam.Close();
        }
    }
}
