using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_1.Models
{
    public class Customer
    {
        public string Customer_ID { get; set; }
        [Required(ErrorMessage = "Customername is must")]
        //[RegularExpression("^[A-Za-z]{1,}$", ErrorMessage = " customername NOT IN CORRECT FORMAT")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Date of birth is  must")]

        [CustomDOB(ErrorMessage = "Invalid")]
        public System.DateTime DateOfBirth { get; set; }
        [RegularExpression("^(?:(?:\\+|0{0,2})91(\\s*[\\-]\\s*)?|[0]?)?[789]\\d{9}$", ErrorMessage = " Contactnumber not in correct format")]
        //[RegularExpression("^[+]91(789){1}[0-9]{9}$",ErrorMessage ="Contatno is incorrect format!!!")]

        [Required(ErrorMessage = "Contactno is must")]
        public long ContactNumber { get; set; }
        [Required(ErrorMessage = "Email is  must")]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string EmailAddress { get; set; }
        [RegularExpression("^[A-Za-z]{1,}$", ErrorMessage = " Country not in correct format")]
        [Required(ErrorMessage = "Country is must")]
        public string Country { get; set; }
        [RegularExpression("^[A-Za-z]{1,}$", ErrorMessage = " City not in correct format")]
        [Required(ErrorMessage = "City is must")]
        public string City { get; set; }
        [Required(ErrorMessage = "Pincode is must")]
        [RegularExpression("^[1-9]{1}[0-9]{5}$", ErrorMessage = "Pincode not in correct format")]

        public int PinCode { get; set; }
        [Required(ErrorMessage = "State is must")]
        public string State { get; set; }
        public string CustomerType { get; set; }
        [Required(ErrorMessage = "Password is must")]

        [RegularExpression("^([a-zA-Z0-9@*#$+]{8,25})$", ErrorMessage = "Password not in correct format")]
        [Custompass(ErrorMessage = "Invalid")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is must")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string Confirmpassword { get; set; }
    }
}