using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team_1.Models;

namespace Team_1.Controllers
{
    public class Team1Controller : Controller
    {
        // GET: Team1
        
        static List<tblHotelDetail> l = null;
        static List<tblHotelDetail> l1 = null;
        static List<tblHotelDetail> HD = null;
        static List<tblBankDetail> slist = null;
        static List<tblBooking> P = null;
        static List<tblCountry> CountryList = null;
        static List<tblCity> CityList = null;

        public ActionResult Index()//this action method displays the view of home page of wowhotel 
        {
            return View();
        }

        public ActionResult Login() //this action method displays the view of login/signup page of wowhotel
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblLogin t)//this method checks the credentials of users and validates them 
        {
            if (ModelState.IsValid)
            {
                string user = Request.Form["UserId"];
                string password = Request.Form["Password"];

                tblLogin t1 = Dbclass.loginn(user,password);

                if (t1 != null)
                {

                    Session["user"] = t1.UserId; //sessionvariables are used to remove that particular session when userlogouts
                    Session["UserType"] = t1.UserType;
                    if (t1.UserType == "Admin")
                    {
                        return RedirectToAction("Login1");






                    }
                    else if (t1.UserType == "Customer")
                    {
                        Session["customerid"] = t1;
                        Session["id"] = t1.UserId;
                        return RedirectToAction("SearchHotelNew");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }






                }
                else
                     ViewBag.msg = "Invalid credentials";
                         return View("Login");





















            }



           
            return View("Login");





















        }
           
        public ActionResult Login1()//this action method displays the view to the admin
        {
          
            l = Dbclass.gethotels1();
            return View(l);
        }
        public ActionResult UserLogin()//this action method displays the view to the user
        {
            return View();
        }
        public ActionResult About()//this action method displays the view of about  page of wowhotel 
        {
            return View();
        }
        public ActionResult Contact()//this action method displays the view of contact page of wowhotel 
        {
            return View();
        }
        public ActionResult Insert()//this action method displays the view of insert action method
        {
            CountryList = Dbclass.getCountry();

            ViewBag.L = CountryList;

            tblHotelDetail E = new tblHotelDetail();
            return View(E);
        }
        [HttpPost]
        public ActionResult Insert(tblHotelDetail E)// this action method is used to insert the data into  hoteldetail table
        {
            if (ModelState.IsValid)
            {

                CountryList = Dbclass.getCountry();
                ViewBag.L = CountryList;
                ViewBag.msg = Dbclass.Inserthotel(E);
               
                return View("Insert");
            }
            CountryList = Dbclass.getCountry();
            ViewBag.L = CountryList;
            return View();
        }
        public ActionResult HotelUpdate(string id)//this action method is used to extract the data from  hoteldetail table
        {
            tblHotelDetail t = Dbclass.gethotels(id);
            return View(t);
        }


        public ActionResult Update(tblHotelDetail E)//this action method is used to update the data in hoteldetail table
        {
            string m = Dbclass.GethotelData(E);
            ViewBag.msg = m;
            return View("HotelUpdate");
        }
        public ActionResult Delete(string id)//this action method is used to delete the data from  hoteldetail table
        {
            ViewBag.msg = Dbclass.Delhotel(id);
            return View();

        }
        
        public ActionResult CustomerLogin()//this action method displays view of customer related page
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer C1)//this action method redirects us to customer registration page where we can give details and register as a member

        {
            if (ModelState.IsValid)
            {
                C1.Customer_ID = Dbclass.getCustomerId(C1.CustomerName);
                C1.CustomerType = Dbclass.getCustomerType(C1.DateOfBirth);
                ViewBag.msg = Dbclass.UserRegistration(C1);
                return View();
            }
            else
                return View("CustomerLogin");
            







        }

        
        

        public ActionResult Logout()// this actionmethod lets the user comeout of the particular page and sessionvariables are used to remove that particular session when userlogouts
        {
            if (Session["user"] != null)
            {
                Session.Abandon();
                Session.Clear();
            }
           
            return RedirectToAction("Login");
        }

        public ActionResult SearchHotelNew()
        {
            //HD = Dbclass.GetHotelDetails();
            //ViewBag.List = HD;
            return View();
        }

        public ActionResult SearchHotel1()
        {


            if (Request.Form["txtSearchHName"] == null && Request.Form["txtSearchCity"] != null)
            {
                //string city = Request.Form["rdbCity"];
                string TS = Request.Form["txtSearchCity"];
                if (TS.Length == 0)
                {
                    ViewBag.msg = "City Name not entered";
                }
                else
                {

                    HD = Dbclass.GetCity(TS);
                    if (HD.Count == 0)
                    {
                        ViewBag.List = null;
                        ViewBag.msg = "no search found ";
                    }
                    else
                    {
                        ViewBag.List = HD;

                    }

                    //HD = Dbclass.GetHotelName(TS);
                }

                return View("SearchHotelNew");
            }

            else if (Request.Form["txtSearchHName"] != null && Request.Form["txtSearchCity"] == null)
            {
                //string HName = Request.Form["rdbHotelName"];
                string TS = Request.Form["txtSearchHName"];
                if (TS.Length == 0)
                {
                    ViewBag.msg = "hotel Name not entered";
                }
                else
                {
                    HD = Dbclass.GetHotelName(TS);
                    if (HD.Count == 0)
                    {
                        ViewBag.List = null;
                        ViewBag.msg = "no search found ";
                    }
                    else
                    {

                        ViewBag.List = HD;

                    }
                }
                return View("SearchHotelNew");

            }
            else if (Request.Form["txtSearchHName"] == null && Request.Form["txtSearchCity"] == null)

                ViewBag.msg = "Invalid Credentials";
            return View("SearchHotelNew");

        }
        public ActionResult booking()                      //booking values user will enter through booking view
        {
            ViewBag.x = Session["id"];
            return View();

        }

        public ActionResult booking1(tblBooking b1)       //values of booking are bought through b1 object
        {
            if (ModelState.IsValid)
            {
                tblLogin z = (tblLogin)Session["customerid"];
                string n = z.UserId;
                if (n == b1.Customer_ID)
                {
                    string s = Dbclass.Hotelbooking(b1);          //validations and billamount is returned through this s
                    if (s.StartsWith("N") || s.StartsWith("a")|| s.StartsWith("H"))      //if validations are not satisfied it goes to booking view and generate which validation is missing
                    {
                        ViewBag.msg = s;
                        return View("booking");
                    }
                    else
                    {
                        ViewBag.msg = s;
                        Session["bill"] = s;
                        Session["var"] = b1;                        //here we are storing object of tblbooking by using sessions so that we can use this value after payment
                        slist = Dbclass.getstate();                //this slist consists values of bankdetails we will use it to populate dropdown values in payment view
                        ViewBag.bankid = slist;
                        return View("payment");
                    }
                    
                }
                else
                {

                    ViewBag.msg = "Please Enter Your CustomerId";
                    return View("booking");
                }
            }
            return View("booking");
        }
        public ActionResult payment()
        {
           
            return View();
        }


        public ActionResult payment1(tblPayment p)
        {

            if (ModelState.IsValid)                             //if validations are satisfied then it goes into model
            {
                tblBooking z = (tblBooking)Session["var"];      //here we are retrieving tblbooking object values that are stored in session variable


                bool s = Dbclass.getpayment(p);
                if (s == true)                                 //if payment is done successfully then it goes to insertion of booking
                {
                    string x = Dbclass.getbooking(z);          //for inserting into booking 
                    ViewBag.g = x;
                }
                return View();
            }
            else
            {
                ViewBag.msg = Session["bill"].ToString();
                slist = Dbclass.getstate();
                ViewBag.bankid = slist;
                return View("payment");                       //it will show where the validation is missing
            }

        }
        public ActionResult gettingbookingdetails()          //By this we will get all the booking details that we have inserted so far
        {
            
            tblLogin c = (tblLogin)Session["customerid"];
            string s = c.UserId;
            P = Dbclass.gettingallbooking(s);                //here all booking values are brought through this gettingallbooking method
            if(P.Count==0)
            {
                ViewBag.List = null;
                ViewBag.msg = "No Booking are there ";
            }
            else
            {
                ViewBag.List = P;
            }


            return View();
            //return View();
        }

        public ActionResult Deletebooking(int id)            //here we will do booking values deleted based on some validations
        {
            ViewBag.msg = Dbclass.Delbooking(id);
            return View();
        }
        public ActionResult bookingupdate(int id)           //booking update can be done here
        {
            
            tblBooking t = Dbclass.getbookingdetails(id);   //which booking id we want to change that we are retrieving from database and populating in view
            Session["opp"] = t;                             //here by using session variable we are storing the object of that bookingid which we want to edit 
            return View(t);
        }


        public ActionResult Updatebook(tblBooking E)
        {
            
            tblBooking s = (tblBooking)Session["opp"];     // retrieving that object by session variable so we can retrieve booking id by this
            string m = Dbclass.GetbookData(E, s);           //here updation is done
            ViewBag.msg = m;
            return View("bookingupdate");
        }

        public ActionResult GetCity(string Country)
        {
            if (ModelState.IsValid)
            {
                // CountryList = Dbclass.getCountry();
                ViewBag.L = CountryList;
                CityList = Dbclass.getCity(Country);
                if (CityList != null)
                {
                    ViewBag.city = new SelectList(CityList, "CITY_NAME", "CITY_NAME");
                    return PartialView("DisplayCities");


                }

            }


            return View("Insert");


        }





















    }
}