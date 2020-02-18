using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Library.Dto
{
    public class BookDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string Author { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        public int GenreID { get; set; }
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 15)]
        public byte NumberInStock { get; set; }
    }
}