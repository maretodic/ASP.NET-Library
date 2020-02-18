using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVC_Library.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string Author { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 15)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}