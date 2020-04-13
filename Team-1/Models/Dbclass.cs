using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Team_1.Models
{
    public class Dbclass
    {
        static Entities1 d= new Entities1();
        List<tblHotelDetail> d1 = new List<tblHotelDetail>();

        public static  tblLogin loginn(string userid,string password)//this method retrieves userid and password from login table and returns it
        {
            var user = (from u in d.tblLogins
                        where u.UserId == userid && u.Password == password 
                        select u).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
                return null;
        }
        public static string Inserthotel(tblHotelDetail H)//this method will insert a record into hoteldetailtable ad registers hotel successfully
        {
            try
            {
                d.tblHotelDetails.Add(H);
                d.SaveChanges();
                return "Registered Successfully and the hotelid is " + H.HotelID;
            }
            catch(DbUpdateException E)
            {
                return "Already The HotelId exist";
            }

        }
        public static List<tblHotelDetail> gethotels1()//this method will give the list of details in hoteldetails table
        {
            var emps = from i in d.tblHotelDetails
                       select i;
            return emps.ToList();
        }
        public static tblHotelDetail gethotels(string hotelid)//this method will return a record in hoteldetail table according to hotelid
        {
            var dept = (from d1 in d.tblHotelDetails
                        where d1.HotelID == hotelid
                        select d1);
            return dept.First();
           
        }
       
        public static string GethotelData(tblHotelDetail H)//this method is used to update the data in hoteldetailtable and update will happen based on hotelid
        {
            try
            {
                var LE = from L in d.tblHotelDetails
                         where L.HotelID == H.HotelID
                         select L;
                tblHotelDetail E = LE.First();
                E.Hotel_Name = H.Hotel_Name;
                E.Hotel_Description = H.Hotel_Description;
                E.Number_of_AC_Rooms = H.Number_of_AC_Rooms;
                E.Number_of_Non_AC_Rooms = H.Number_of_Non_AC_Rooms;
                E.Rate_for_one_night_for_one_adult_AC = H.Rate_for_one_night_for_one_adult_AC;
                E.Rate_for_one_night_for_one_adult_NONAC = H.Rate_for_one_night_for_one_adult_NONAC;
                E.Rate_for_one_night_for_one_children_AC = H.Rate_for_one_night_for_one_children_AC;
                E.Rate_for_one_night_for_one_children_NONAC = H.Rate_for_one_night_for_one_children_NONAC;

                d.SaveChanges();
            }
            catch(DbEntityValidationException V)
            {
                return "Not in the given Range";

            }
            catch(InvalidOperationException E)
            {
                return "You Cannot Update This Field";
            }
            return "Updated Successfully";
        }

        public static string Delhotel(string hotelid)//this method deletes the records in hoteldetailtable based on hotelid
        {
            try
            {
                var hote = from i in d.tblHotelDetails
                           where i.HotelID == hotelid
                           select i;
                tblHotelDetail h = hote.First();
                tblBooking book = (from i in d.tblBookings
                                   where i.HotelID == h.HotelID
                                   select i).FirstOrDefault(); 
                if(book==null)
                {
                    d.tblHotelDetails.Remove(h);
                    d.SaveChanges();
                    return "Data Deleted Succesfully";
                }
                else
                {
                    return "Hotel details cannot be deleted because of prior cutomers registration";
                }
            }
            catch(Exception E)
            {

            }
            return null;
        }
        
        public static string UserRegistration(Customer C1)//this method is used to add data in both login and customer table 
        {
           

                tblCustomer C = new tblCustomer();
                tblLogin L = new tblLogin();
                C.Customer_ID = C1.Customer_ID;
                C.CustomerName = C1.CustomerName;


                C.DateOfBirth = C1.DateOfBirth;
                C.EmailAddress = C1.EmailAddress;
                C.ContactNumber = C1.ContactNumber;
                C.Country = C1.Country;
                 C.State = C1.State;
                 C.City = C1.City;
                C.PinCode = C1.PinCode;
              
                C.CustomerType = C1.CustomerType;
                d.tblCustomers.Add(C);
                d.SaveChanges();
                string CustId = C.Customer_ID;
                L.UserId = CustId;
                L.Password =C1.Password;
                L.UserType = "Customer";
                 d.tblLogins.Add(L);
                 d.SaveChanges();



            return "User Registration Done Successfully with customerid " +C1.Customer_ID;

        }
        


        
        public static string getCustomerId(string Customername)//this method is used for autogeneration of customerid according to given conditions
        {
            string s = null;
            ObjectParameter aid = new ObjectParameter("aid", typeof(string));
            ObjectResult<string> ob = d.Proc1(Customername);
            List<string> L = ob.ToList();
            if (L.Count != 0)
            {
                int ai = int.Parse(L[0].Substring(1)) + 1;
                s = Customername.Substring(0, 1) + string.Format("{0000}", ai);
            }
            else
                s = Customername.Substring(0, 1) + "1000";
            return s;
        }
        public static string getCustomerType(DateTime Dateofbirth)//this method is used for autogeneration of customertype according to age
        {
            DateTime d = Convert.ToDateTime(Dateofbirth);
            DateTime dt = DateTime.Today;
            int age = (int)dt.Subtract(d).TotalDays / 365;
            if (d > dt)
            {
                return "date shouldnot be greater than todays date";
            }
            else if (age > 1 && age < 50)
            {
                return "normal citizen";
            }
            else
                return "senior citizen";

        }
        public static List<tblHotelDetail> GetHotelDetails()
        {
            var E = from E1 in d.tblHotelDetails
                    select E1;
            return E.ToList();

        }
        public static List<tblHotelDetail> GetCity(string City)
        {
            List<tblHotelDetail> l = null;
            var E1 = from E2 in d.tblHotelDetails
                     where E2.City == City
                     select E2;
            l = E1.ToList();
            return l;
        }
        public static List<tblHotelDetail> GetHotelName(string HName)
        {
            var E1 = from E2 in d.tblHotelDetails
                     where E2.Hotel_Name == HName
                     select E2;
            return E1.ToList();
        }

        public static bool getpayment(tblPayment p)                    //payment values are inserted in tblpayment
        {
            tblPayment p1 = new tblPayment();
            var E6 = from E2 in d.tblCustomers
                     where E2.Customer_ID == p.Customer_ID
                     select E2;
            tblCustomer h3 = E6.First();
            if (h3.CustomerType == "senior citizen")
            {
                p1.Customer_ID = p.Customer_ID;
                p1.Bank_ID = p.Bank_ID;
                p1.Credit_card_Number = p.Credit_card_Number;
                p1.Card_Type = p.Card_Type;
                p1.Name_on_Card = p.Name_on_Card;
                p1.Date_of_Transaction = DateTime.Now;
                p1.Expiry_Date = p.Expiry_Date;
                p1.CVV_Number = p.CVV_Number;
                p1.Account_Number = p.Account_Number;
                p1.Pin_Number = p.Pin_Number;
                p1.Amount = p.Amount - ((5 * p.Amount) / 100);
                d.tblPayments.Add(p1);
                d.SaveChanges();
                return true;
            }
            else
            {
                p1.Customer_ID = p.Customer_ID;
                p1.Bank_ID = p.Bank_ID;
                p1.Credit_card_Number = p.Credit_card_Number;
                p1.Card_Type = p.Card_Type;
                p1.Name_on_Card = p.Name_on_Card;
                p1.Date_of_Transaction = DateTime.Now;
                p1.Expiry_Date = p.Expiry_Date;
                p1.CVV_Number = p.CVV_Number;
                p1.Account_Number = p.Account_Number;
                p1.Pin_Number = p.Pin_Number;
                p1.Amount = p.Amount;
                d.tblPayments.Add(p1);
                d.SaveChanges();
                return true;
            }

        }
        public static string getbooking(tblBooking z)                     //booking is done here and values are inserted in tblbooking
        {
            tblBooking b5 = new tblBooking();
            var E1 = from E2 in d.tblHotelDetails
                     where E2.HotelID == z.HotelID
                     select E2;
            tblHotelDetail h1 = E1.First();
            if (z.Room_Type == "AC")
            {
                b5.Customer_ID = z.Customer_ID;
                b5.HotelID = z.HotelID;
                b5.BookingDate = DateTime.Now;
                b5.ArrivalDate = z.ArrivalDate;
                b5.DepartureDate = z.DepartureDate;
                b5.Number_of_Adults = z.Number_of_Adults;
                b5.Number_of_Children = z.Number_of_Children;
                b5.Number_of_Nights = z.Number_of_Nights;
                b5.Room_Type = z.Room_Type;
                b5.Number_of_Rooms = z.Number_of_Rooms;
                d.tblBookings.Add(b5);
                d.SaveChanges();
                h1.Number_of_AC_Rooms = h1.Number_of_AC_Rooms - z.Number_of_Rooms;
                d.SaveChanges();
            }
            else
            {
                b5.Customer_ID = z.Customer_ID;
                b5.HotelID = z.HotelID;
                b5.BookingDate = DateTime.Now;
                b5.ArrivalDate = z.ArrivalDate;
                b5.DepartureDate = z.DepartureDate;
                b5.Number_of_Adults = z.Number_of_Adults;
                b5.Number_of_Children = z.Number_of_Children;
                b5.Number_of_Nights = z.Number_of_Nights;
                b5.Room_Type = z.Room_Type;
                b5.Number_of_Rooms = z.Number_of_Rooms;
                d.tblBookings.Add(b5);
                d.SaveChanges();
                h1.Number_of_Non_AC_Rooms = h1.Number_of_Non_AC_Rooms - z.Number_of_Rooms;
                d.SaveChanges();
            }
            return "Hotel reserved successfully with booking id" + b5.Booking_ID;

        }
        public static List<tblBankDetail> getstate()               //we are getting all the tblbankdetails this we will use for populating in dropdown bankid of payment view
        {
            var bankid = from s in d.tblBankDetails
                         select s;
            return bankid.ToList();
        }
        public static string Hotelbooking(tblBooking b1)          //here we will do validations and we will generate bill amount
        {
            try
            {
                tblBooking b = new tblBooking();
                var E1 = from E2 in d.tblHotelDetails
                         where E2.HotelID == b1.HotelID
                         select E2;
                tblHotelDetail h = E1.First();
                DateTime D = Convert.ToDateTime(b1.ArrivalDate);
                DateTime TD = DateTime.Today;


                if (D > TD)
                {
                    if (b1.Room_Type == "AC" && b1.Number_of_Rooms <= h.Number_of_AC_Rooms)
                    {

                        if (b1.Number_of_Nights > 5)
                        {
                            double billamount = (b1.Number_of_Adults * h.Rate_for_one_night_for_one_adult_AC)
                            + (b1.Number_of_Children * h.Rate_for_one_night_for_one_children_AC);
                            billamount = billamount - ((2.5 * billamount) / 100);
                            return billamount.ToString();
                        }
                        else
                        {
                            double billamount = (b1.Number_of_Adults * h.Rate_for_one_night_for_one_adult_AC)
                            + (b1.Number_of_Children * h.Rate_for_one_night_for_one_children_AC);
                            return billamount.ToString();
                        }
                    }
                    else if (b1.Room_Type == "NONAC" && b1.Number_of_Rooms <= h.Number_of_Non_AC_Rooms)
                    {

                        if (b1.Number_of_Nights > 5)
                        {
                            double billamount = (b1.Number_of_Adults * h.Rate_for_one_night_for_one_adult_NONAC) +
                                (b1.Number_of_Children * h.Rate_for_one_night_for_one_children_NONAC);
                            billamount = billamount - ((2.5 * billamount) / 100);
                            return billamount.ToString();
                        }
                        else
                        {
                            double billamount = (b1.Number_of_Adults * h.Rate_for_one_night_for_one_adult_NONAC) +
                                (b1.Number_of_Children * h.Rate_for_one_night_for_one_children_NONAC);
                            return billamount.ToString();
                        }
                    }
                    else
                    {
                        return "No available rooms";
                    }
                }


                else
                {
                    return "arrival date must be greater than current date";
                }
            }
catch(InvalidOperationException E)
            {
                return "Hotel Not Found";
            }
            


        }

        public static List<tblBooking> gettingallbooking(string s)                       //we are getting all tblbooking values inserted so far 
        {
            var E9 = from E1 in d.tblBookings
                     where E1.Customer_ID==s
                     select E1;
            return E9.ToList();
        }
        public static string Delbooking(int Booking_ID)                          //here booking details can be deleted
        {

            try
            {

                var book = from i in d.tblBookings
                           where i.Booking_ID == Booking_ID
                           select i;

                tblBooking b = book.First();
                var E1 = from E2 in d.tblHotelDetails
                         where E2.HotelID == b.HotelID
                         select E2;
                tblHotelDetail h2 = E1.First();
                DateTime D = Convert.ToDateTime(b.BookingDate);
                DateTime TD = DateTime.Today;


                TimeSpan limit = TD - D;
                var E8 = from E9 in d.tblPayments
                         where E9.TransactionID == b.Booking_ID
                         select E9;
                tblPayment p2 = E8.First();
                if (limit.Days <= 3)                                       //if we want to cancel  within 3 days after booking then cancellation is possible
                {
                    if (b.Room_Type == "AC")
                    {

                        d.tblBookings.Remove(b);
                        h2.Number_of_AC_Rooms = b.Number_of_Rooms + h2.Number_of_AC_Rooms;
                        d.tblPayments.Remove(p2);
                        d.SaveChanges();
                        return "Successfully deleted";
                    }
                    else
                    {
                        d.tblBookings.Remove(b);
                        h2.Number_of_Non_AC_Rooms = b.Number_of_Rooms + h2.Number_of_Non_AC_Rooms;
                        d.tblPayments.Remove(p2);
                        d.SaveChanges();
                        return "Successfully deleted";
                    }
                }
                else
                {
                    return "Cancellation is not available";
                }
            }
            catch(InvalidOperationException E)
            {

                return "You cannot cancel the booking now";
            }

        }
        public static tblBooking getbookingdetails(int Booking_ID)              //here we are getting required details of booking id that we want to change
        {
            var bookid = (from d1 in d.tblBookings
                          where d1.Booking_ID == Booking_ID
                          select d1);
            return bookid.First();

        }
        public static string GetbookData(tblBooking H, tblBooking s)             //here we are updating values of booking and changing availabilty of rooms based on updation and generating amount
        {
            try
            {
                // tblBooking b = new tblBooking();
                var E1 = from E2 in d.tblHotelDetails
                         where E2.HotelID == H.HotelID
                         select E2;
                tblHotelDetail h = E1.First();
                DateTime D = Convert.ToDateTime(H.ArrivalDate);
                DateTime TD = DateTime.Today;


                var b1 = from p9 in d.tblBookings
                         where p9.Booking_ID == s.Booking_ID
                         select p9;
                tblBooking x = b1.First();
                var p1 = from p2 in d.tblPayments
                         where p2.TransactionID == s.Booking_ID
                         select p2;
                tblPayment pp = p1.First();

                if (D > TD)
                {
                    if (H.Room_Type == "AC" && H.Number_of_Rooms <= h.Number_of_AC_Rooms)
                    {

                        if (H.Number_of_Nights > 5)
                        {
                            double billamount = (H.Number_of_Adults * h.Rate_for_one_night_for_one_adult_AC)
                            + (H.Number_of_Children * h.Rate_for_one_night_for_one_children_AC);
                            billamount = billamount - ((2.5 * billamount) / 100);
                            pp.Amount = (int)billamount;

                            d.SaveChanges();
                            h.Number_of_AC_Rooms = h.Number_of_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            d.SaveChanges();
                            x.Customer_ID = H.Customer_ID;
                            x.HotelID = H.HotelID;
                            x.BookingDate = DateTime.Now;
                            x.ArrivalDate = H.ArrivalDate;
                            x.DepartureDate = H.DepartureDate;
                            x.Number_of_Adults = H.Number_of_Adults;
                            x.Number_of_Children = H.Number_of_Children;
                            x.Number_of_Nights = H.Number_of_Nights;
                            x.Room_Type = H.Room_Type;
                            x.Number_of_Rooms = H.Number_of_Rooms;

                            d.SaveChanges();
                            // h.Number_of_AC_Rooms = h.Number_of_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            // d.SaveChanges();
                            return "updated successfully";

                        }
                        else
                        {
                            double billamount = (H.Number_of_Adults * h.Rate_for_one_night_for_one_adult_AC)
                            + (H.Number_of_Children * h.Rate_for_one_night_for_one_children_AC);
                            pp.Amount = (int)billamount;

                            d.SaveChanges();
                            h.Number_of_AC_Rooms = h.Number_of_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            d.SaveChanges();
                            x.Customer_ID = H.Customer_ID;
                            x.HotelID = H.HotelID;
                            x.BookingDate = DateTime.Now;
                            x.ArrivalDate = H.ArrivalDate;
                            x.DepartureDate = H.DepartureDate;
                            x.Number_of_Adults = H.Number_of_Adults;
                            x.Number_of_Children = H.Number_of_Children;
                            x.Number_of_Nights = H.Number_of_Nights;
                            x.Room_Type = H.Room_Type;
                            x.Number_of_Rooms = H.Number_of_Rooms;
                            d.SaveChanges();
                            //h.Number_of_AC_Rooms = h.Number_of_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            //d.SaveChanges();

                            return "updated successfully";
                        }
                    }
                    else if (H.Room_Type == "NONAC" && H.Number_of_Rooms <= h.Number_of_Non_AC_Rooms)
                    {

                        if (H.Number_of_Nights > 5)
                        {
                            double billamount = (H.Number_of_Adults * h.Rate_for_one_night_for_one_adult_NONAC) +
                                (H.Number_of_Children * h.Rate_for_one_night_for_one_children_NONAC);
                            billamount = billamount - ((2.5 * billamount) / 100);
                            pp.Amount = (int)billamount;

                            d.SaveChanges();
                            h.Number_of_Non_AC_Rooms = h.Number_of_Non_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            d.SaveChanges();
                            x.Customer_ID = H.Customer_ID;
                            x.HotelID = H.HotelID;
                            x.BookingDate = DateTime.Now;
                            x.ArrivalDate = H.ArrivalDate;
                            x.DepartureDate = H.DepartureDate;
                            x.Number_of_Adults = H.Number_of_Adults;
                            x.Number_of_Children = H.Number_of_Children;
                            x.Number_of_Nights = H.Number_of_Nights;
                            x.Room_Type = H.Room_Type;
                            x.Number_of_Rooms = H.Number_of_Rooms;

                            d.SaveChanges();
                            //h.Number_of_Non_AC_Rooms = h.Number_of_Non_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            //d.SaveChanges();

                            return "updated successfully";
                        }
                        else
                        {
                            double billamount = (H.Number_of_Adults * h.Rate_for_one_night_for_one_adult_NONAC) +
                                (H.Number_of_Children * h.Rate_for_one_night_for_one_children_NONAC);
                            pp.Amount = (int)billamount;

                            d.SaveChanges();
                            h.Number_of_Non_AC_Rooms = h.Number_of_Non_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            d.SaveChanges();
                            x.Customer_ID = H.Customer_ID;
                            x.HotelID = H.HotelID;
                            x.BookingDate = DateTime.Now;
                            x.ArrivalDate = H.ArrivalDate;
                            x.DepartureDate = H.DepartureDate;
                            x.Number_of_Adults = H.Number_of_Adults;
                            x.Number_of_Children = H.Number_of_Children;
                            x.Number_of_Nights = H.Number_of_Nights;
                            x.Room_Type = H.Room_Type;
                            x.Number_of_Rooms = H.Number_of_Rooms;

                            d.SaveChanges();
                            //h.Number_of_Non_AC_Rooms = h.Number_of_Non_AC_Rooms + x.Number_of_Rooms - H.Number_of_Rooms;
                            //d.SaveChanges();

                            return "updated successfully";
                        }
                    }
                    else
                    {
                        return "No available rooms";
                    }
                }


                else
                {
                    return "arrival date must be greater than current date";
                }
            }
            catch(InvalidOperationException E)
            {
                return " Scheduled Time is Over For Updating";
            }


        }

        //retrieves list of Countries from database
        public static List<tblCountry> getCountry()
        {
            var country = from C in d.tblCountries
                          select C;
            return country.ToList();
        }
        ////retrieves list of Cities from database
        public static List<tblCity> getCity(string cname)
        {
            var cid = (from c in d.tblCountries
                       where c.COUNTRY_NAME == cname
                       select c).FirstOrDefault();
            if (cid != null)
            {
                var city = from c in d.tblCities
                           where c.COUNTRY_ID == cid.COUNTRY_ID
                           select c;
                return city.ToList();
            }
            return null;
        }










    }





}