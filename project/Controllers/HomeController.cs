using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Mail;

using System.Data.Entity;
using System.Text;
using System.Runtime.InteropServices;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        ServiceContext Db;
        public HomeController()
        {
            Db = new ServiceContext();
        }
        #region index
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        #endregion

        public ActionResult Logout() {
            Session["id"] = null;
            Session["type"] = null;
            Session["log"] = null;
            return RedirectToAction("Index");
        }
        #region login
        [HttpPost]
        public ActionResult Login(User user)
        {
            string type;
            //User val = db.Users.Find(user.Email);
            var val = Db.Users.Where(ww => ww.Email == user.Email);
            if (val.Count() != 0)
            {
                var pass = val.Select(ww => ww.Password).First();
                if (user.Password == pass)
                {
                    Session["pass"] = null;
                    type = val.Select(ww => ww.Type).First();
                    if (type == "admin")
                    { //Session.Add("u_id", id);
                      //ViewBag.u = Db.Users;

                        int id = val.Select(ww => ww.Id).First();
                        //HttpCookie cookie = new HttpCookie("id", id.ToString());
                        //cookie.Expires = DateTime.Now.AddSeconds(20);
                        //// cookie["id"] = id.ToString();
                        //Response.Cookies.Add(cookie);
                        ////Response.Redirect("Page2Admin");
                        Session["log"] = "out";
                        Session["type"] = "admin";
                        Session["id"] = id;
                        
                        return RedirectToAction("Page2Admin");

                    }
                    else if (type == "user")
                    {
                        int _id = val.Select(ww => ww.Id).First();
                        //HttpCookie cookiee = new HttpCookie("id", _id.ToString());
                        //cookiee.Expires = DateTime.Now.AddSeconds(20);
                        //// cookie["id"] = id.ToString();
                        //Response.Cookies.Add(cookiee);
                        Session["log"] = "out";
                        Session["type"] = "user";
                        Session["id"] = _id;
                        return RedirectToAction("Page2User");
                    }
                }
                else
                {

                    Session["pass"] = "not";
                }
            }
            Session["id"] = null;
            Session["type"] = null;
            Session["log"] = null;
            return View("Index");
        }
        #endregion

        #region register
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                u.Type = "user";
                Db.Users.Add(u);
                Db.SaveChanges();
                Session["log"] = "out";
                Session["type"] = "user";
                var val = Db.Users.Where(ww => ww.Email == u.Email);
                int id = val.Select(ww => ww.Id).First();
                //int id = u.Id;
                Session["id"] = id;
                return RedirectToAction("Page2User");
            }
            else
            {
                return View("Index");
            }
        }
        #endregion

        #region page2User
        [HttpGet]
        public ActionResult Page2User()
        {
            //ViewBag.u = new SelectList(Db.Users.ToList(), "Id");
            var c = Db.Cities.ToList();
            return View("Page2User", c);
        }
        #endregion

        #region page2admin
        [HttpGet]
        public ActionResult Page2Admin()
        {
            //ViewBag.u = new SelectList(Db.Users.ToList(), "Id");
            var c = Db.Cities.ToList();
            return View("Page2Admin", c);
        }
        //[HttpGet]
        ////public ActionResult Page2AdminDelete(int id)
        ////{
        ////    var c = Db.Cities.Find(id);
        ////    Db.Cities.Remove(c);
        ////    Db.SaveChanges();
        ////    return Redirect(Request.UrlReferrer.ToString());
        ////    //return RedirectToAction("Page2Admin");
        ////}
        #endregion

        #region Page3User
        [HttpGet]
        //public ActionResult Page3User(int l ,int id)
        //{
        //    if (l != 0)
        //    {
        //        HttpCookie cookiee = new HttpCookie("id", l.ToString());
        //        cookiee.Expires = DateTime.Now.AddSeconds(20);
        //        // cookie["id"] = id.ToString();
        //        Response.Cookies.Add(cookiee);

        //    }
        //    var city = Db.Cities.Find(id);
        //    return View("Page3User", city);
        //}
        public ActionResult Page3User(int id)
        {
            var city = Db.Cities.Find(id);
            return View("Page3User", city);
        }
        #endregion

        #region Page3Admin
        public ActionResult Page3Admin(int id)
        {
            Session["cityid"] = id;
            var city = Db.Cities.Find(id);
            return View("Page3Admin", city);
        }
        #endregion

        #region Page4User
        [HttpGet]
        public ActionResult Page4User(int l, int id)
        {
            //if (n != 0)
            //{
            //    HttpCookie cookiee = new HttpCookie("id", n.ToString());
            //    cookiee.Expires = DateTime.Now.AddSeconds(20);
            //    // cookie["id"] = id.ToString();
            //    Response.Cookies.Add(cookiee);

            //}
            if (l == 1)
            {
                var sch = Db.Schools.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4UserSchool", sch);
            }
            else if (l == 2)
            {
                var sch = Db.Restaurants.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4UserRestaurant", sch);
            }
            else if (l == 3)
            {
                var sch = Db.Hospitals.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4UserHospital", sch);
            }
            else if (l == 4)
            {
                var sch = Db.Hotels.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4UserHotel", sch);
            }
            else
            {
                return View("Index");
            }
        }
        #endregion

        #region Page4Admin
        [HttpGet]
        public ActionResult Page4Admin(int l)
        {
         string  id1 = Session["cityid"].ToString();
            int id = int.Parse(id1);
            if (l == 1)
            {
                var sch = Db.Schools.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4AdminSchool", sch);
            }
            else if (l == 2)
            {
                var sch = Db.Restaurants.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4AdminRestaurant", sch);
            }
            else if (l == 3)
            {
                var sch = Db.Hospitals.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4AdminHospital", sch);
            }
            else if (l == 4)
            {
                var sch = Db.Hotels.Include(ww => ww.City).Where(ww => ww.City_Id == id).ToList();
                return View("Page4AdminHotel", sch);
            }
            else
            {
                return View("Index");
            }
        }
        #endregion

        #region DetailsUser
        [HttpGet]
        public ActionResult DetailsUserHospital(int id)
        {
            var sc = Db.Hospitals.Find(id);
            return View(sc);
        }
        [HttpGet]
        public ActionResult DetailsUserHotel(int id)
        {
            var sc = Db.Hotels.Find(id);
            return View(sc);
        }
        [HttpGet]
        public ActionResult DetailsUserSchool(int id)
        {
            var sc = Db.Schools.Find(id);
            return View(sc);
        }
        [HttpGet]
        public ActionResult DetailsUserRestaurant(int id)
        {
            var sc = Db.Restaurants.Find(id);
            return View(sc);
        }
        #endregion

        #region DetailsAdmin
        //hospital
        [HttpGet]
        public ActionResult DetailsAdminHospitalEdit(int id)
        {
            var sc = Db.Hospitals.Find(id);
            return View(sc);
        }
        [HttpPost]
        public ActionResult DetailsAdminHospitalEdit(Hospital Newhos)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Newhos).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 3 });
                //return View("DetailsAdminHospitalEdit");
            }
            else
            {
                return View("DetailsAdminHospitalEdit");
            }
        }
        [HttpGet]
        public ActionResult DetailsAdminHospitalDelete(int id)
        {
            var hos = Db.Hospitals.Find(id);
            Db.Hospitals.Remove(hos);
            Db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
            //return RedirectToAction("Page3Admin");
        }
        //hotel
        [HttpGet]
        public ActionResult DetailsAdminHotelEdit(int id)
        {
            var sc = Db.Hotels.Find(id);
            return View(sc);
        }
        [HttpPost]
        public ActionResult DetailsAdminHotelEdit(Hotel Newhot)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Newhot).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 4 });
                //return View("DetailsAdminHotelEdit");
            }
            else
            {
                return View("DetailsAdminHotelEdit");
            }
        }
        [HttpGet]
        public ActionResult DetailsAdminHotelEditDelete(int id)
        {
            var hot = Db.Hotels.Find(id);
            Db.Hotels.Remove(hot);
            Db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
            //return RedirectToAction("Page3Admin");
        }
        //school
        [HttpGet]
        public ActionResult DetailsAdminSchoolEdit(int id)
        {
            var sc = Db.Schools.Find(id);
            return View(sc);
        }
        [HttpPost]
        public ActionResult DetailsAdminSchoolEdit(School Newsc)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Newsc).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 1 });
                //return RedirectToAction("DetailsAdminSchoolEdit");
            }
            else
            {
                return View("DetailsAdminSchoolEdit");
            }
        }
        [HttpGet]
        public ActionResult DetailsAdminSchoolEditDelete(int id)
        {
            var s = Db.Schools.Find(id);
            Db.Schools.Remove(s);
            Db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
            //return RedirectToAction("Page3Admin");
        }
        //restaurant
        [HttpGet]
        public ActionResult DetailsAdminRestaurantEdit(int id)
        {
            var rs = Db.Restaurants.Find(id);
            return View(rs);
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="Newres"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DetailsAdminRestaurantEdit(Restaurant Newres)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Newres).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 2 });
                //return View("DetailsAdminRestaurantEdit");
            }
            else
            {
                return View("DetailsAdminRestaurantEdit");
            }
        }
        [HttpGet]
        public ActionResult DetailsAdminRestaurantEditDelete(int id)
        {
            var res = Db.Restaurants.Find(id);
            Db.Restaurants.Remove(res);
            Db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
            //return RedirectToAction("Page3Admin");
        }
        #endregion

        #region add city
        [HttpGet]
        public ActionResult AddCity()
        {
            return View();
        }
        [HttpPost]/////////////////////////////////////////////////////////////////////////
        public ActionResult AddCity(City c)
        {
          
              

            if (ModelState.IsValid)
            {
                Db.Cities.Add(c);
                Db.SaveChanges();
                var k = Db.Cities.ToList();
                //return Redirect(Request.UrlReferrer.ToString());
                return RedirectToAction("Page2Admin");
            }
            else
            {
                return RedirectToAction("AddCity");
            }
        }
        #endregion

        #region add Service
        //school
        [HttpGet]
        public ActionResult AddSchool()
        {
            ViewBag.c = new SelectList(Db.Cities.ToList(), "City_Id", "City_Name", 1);
            return View();
        }
        [HttpPost]
        public ActionResult AddSchool(School s)
        {
            string c = Session["cityid"].ToString();
            s.City_Id = int.Parse(c);
            if (ModelState.IsValid)
            {
                Db.Schools.Add(s);
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 1 });
                //return RedirectToAction("Page3Admin");
            }
            else
            {
                return View(" AddSchool");
            }
        }
        //restaurant
        [HttpGet]
        public ActionResult AddRestaurant()
        {
            ViewBag.c = new SelectList(Db.Cities.ToList(), "City_Id", "City_Name", 1);
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurant(Restaurant r)
        {
            string c = Session["cityid"].ToString();
            r.City_Id = int.Parse(c);
            if (ModelState.IsValid)
            {
                Db.Restaurants.Add(r);
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 2 });
                //return RedirectToAction("Page3Admin");
            }
            else
            {
                return View("AddRestaurant");
            }
        }
        //Hotel
        [HttpGet]
        public ActionResult AddHotel()
        {
            ViewBag.c = new SelectList(Db.Cities.ToList(), "City_Id", "City_Name", 1);
            return View();
        }
        [HttpPost]
        public ActionResult AddHotel(Hotel hot)
        {
            string c = Session["cityid"].ToString();
            hot.City_Id = int.Parse(c);

            if (ModelState.IsValid)
            {
                Db.Hotels.Add(hot);
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 4 });
                //return RedirectToAction("Page3Admin");
            }
            else
            {
                return View("AddHotel");
            }
        }
        //hospital
        [HttpGet]
        public ActionResult AddHospital()
        {
            ViewBag.c = new SelectList(Db.Cities.ToList(), "City_Id", "City_Name", 1);
            return View();
        }
        [HttpPost]
        public ActionResult AddHospital(Hospital hos)
        {
            string c = Session["cityid"].ToString();
            hos.City_Id = int.Parse(c);
            if (ModelState.IsValid)
            {
                Db.Hospitals.Add(hos);
                Db.SaveChanges();
                return RedirectToAction("Page4Admin", new { l = 3 });

                //return RedirectToAction("Page3Admin");
            }
            else
            {
                return View("AddHospital");
            }
        }
        #endregion

        #region add admin
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(User user)
        {
            user.Type = "admin";
            if (ModelState.IsValid)
            {
                Db.Users.Add(user);
                Db.SaveChanges();
                return RedirectToAction("Page2Admin");
                //return RedirectToAction("Page2Admin");
            }

            else
            {
                return RedirectToAction("AddAdmin");
            }

        }
        #endregion

        #region profile
        [HttpGet]
        public ActionResult ViewProfile()
        {
            var id = Session["id"];
            var user = Db.Users.Find(id);
            return View("ViewProfile", user);
        }
        #endregion

        #region edit profile
        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            var u = Db.Users.Find(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult EditProfile(User Newu, int id)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(Newu).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                //Alerts.Success("Success alert message!", "Test Alert");
                var u = Db.Users.Find(id);
                return RedirectToAction("ViewProfile", u);
            }
            else
            {
                var u = Db.Users.Find(id);
                return View("Page2Admin", u);
            }
        }
        #endregion

        #region complaint
        //[HttpPost]
        //public ActionResult AddComplaint(Complaint co)
        //{          
        //    if (ModelState.IsValid)
        //    {
        //        //ViewData["c"] = co;
        //        Db.Complaints.Add(co);
        //        Db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    else
        //    {
        //       return RedirectToAction("Index");
        //    }

        //}
        #endregion

        #region contact us
        [HttpPost]
        public ActionResult Contact(ContactModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("ahmed.fawy134@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Supject;
                    msz.Body = vm.Message;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    (vm.Email, vm.Password);

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View("Index");
        }
        public ActionResult Error()
        {
            return View();
        }
        #endregion

        #region Delete City
        [HttpGet]

        public ActionResult Delete(int id)
        {
            var mov = Db.Cities.Find(id);

           Db.Cities.Remove(mov);
            Db.SaveChanges();


            return RedirectToAction("Page2Admin");
        }
        #endregion

    }
}