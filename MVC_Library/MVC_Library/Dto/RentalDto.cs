using MVC_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Dto
{
    public class RentalDto
    {
        public int ID { get; set; }

        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}