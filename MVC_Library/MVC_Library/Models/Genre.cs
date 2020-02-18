using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Library.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
    }
}