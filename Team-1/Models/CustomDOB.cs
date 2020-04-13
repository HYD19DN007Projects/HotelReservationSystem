using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_1.Models
{
    public class CustomDOB:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime D = Convert.ToDateTime(value);
            if (D > DateTime.Now)
            {
                return new ValidationResult("Dateofbirth cannot be greater than today's date");
            }
            else
                return ValidationResult.Success;
        }
    }
}