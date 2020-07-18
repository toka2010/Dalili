using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace project.Models
{
    public class ContactModel

    {

        [Required(ErrorMessage = "First Name is required")]

        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Supject { get; set; }
            [Required]
           
              public string Message { get; set; }  
       

       
    }
}