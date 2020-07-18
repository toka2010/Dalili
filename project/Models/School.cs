using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class School
    {
        [Key]
        public int School_id { get; set; }

        public string School_Name { get; set; }

        [ForeignKey("City")]
        public int City_Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Image1 { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Image2 { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Image3 { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public int Phone { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }

        public virtual City City { get; set; }
    }
}