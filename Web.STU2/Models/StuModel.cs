using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.STU2.Models
{
    public class StuModel
    {
        [Range(1000, 10000)]
        public int StudentId { get; set; }
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }
        //public int Age { get {return (DateTime.Now.Year - DOB.Year) ; } set=>Age=value; }
    }
}