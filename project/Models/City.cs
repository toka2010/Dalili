using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class City
    {
        [Key]
        public int City_Id { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City_Name { get; set; }
        public string City_Image { get; set; }

     

      

        public virtual ICollection<Hospital> Hospitals { get; set; } = new HashSet<Hospital>();

        public virtual ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();

        public virtual ICollection<School> Schools { get; set; } = new HashSet<School>();
    }
}