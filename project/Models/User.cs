using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [EmailAddress(ErrorMessage = "invalid email")]
       // [Remote("ChkEmail", "User", AdditionalFields = "Id", ErrorMessage = "This Email is Already Exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name = "conFirm Passward ")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passward & Confirm Passward aren't the same")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //[Phone]
        public int? Phone { get; set; }

        public string Type { get; set; }

        
    }
}