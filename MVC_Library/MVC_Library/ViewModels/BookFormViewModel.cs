using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_Library.Models;

namespace MVC_Library.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
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
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 15)]
        public byte NumberInStock { get; set; }
        public string PageTitle
        {
            get
            {
                return ID != 0 ? "Edit Book" : "New Book";
            }
        }

        public BookFormViewModel()
        {
            ID = 0;
        }

        public BookFormViewModel(Book book)
        {
            ID = book.ID;
            Title = book.Title;
            Author = book.Author;
            ISBN = book.ISBN;
            GenreID = book.GenreID;
            NumberInStock = book.NumberInStock;
        }
    }
}