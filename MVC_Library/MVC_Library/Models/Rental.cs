using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Library.Models
{
    public class Rental
    {
        public int ID { get; set; }
        [Required]
        public Member Member { get; set; }
        [Required]
        public Book Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}