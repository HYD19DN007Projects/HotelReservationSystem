//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblLogin
    {
        [Required(ErrorMessage = "USERID IS MUST")]
        [RegularExpression("^[A-Z]{1}[0-9]{4}$", ErrorMessage = "USERID IS INCORRECT FORMAT")]

        public string UserId { get; set; }
        [Required(ErrorMessage = "PASSWORD IS MUST")]
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
