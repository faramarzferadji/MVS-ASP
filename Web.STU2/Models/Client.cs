using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.STU2.Models
{

    public class Client
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "PassWord")]
        [Range(1000, 10000)]
        public int Passwords { get; set; }
    }
}

