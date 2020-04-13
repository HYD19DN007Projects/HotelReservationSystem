using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team_1.Models
{
    public class Custompass:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string password = null;
                Customer t = (Customer)validationContext.ObjectInstance;
                password = (string)value;

                if (password.Contains(t.CustomerName))
                {
                    return new ValidationResult("Password  cannot  contain username");
                }

                else

                    return ValidationResult.Success;
            }
            catch(NullReferenceException E)
            {
                return new ValidationResult("Customer name is must");
            }
            
           
            }
          
        
    }
}