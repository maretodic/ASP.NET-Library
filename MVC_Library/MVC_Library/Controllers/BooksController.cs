using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_Library.Models;
using MVC_Library.ViewModels;

namespace MVC_Library.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Books
        public ViewResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.ID == id);
            if( book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var vm = new BookFormViewModel
            {
                Genres = genres
            };
            return View("BookForm", vm);
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }

            var vm = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MemberForm", viewModel);
            }

            if(book.ID == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb= _context.Books.SingleOrDefault(m => m.ID == book.ID);
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.ISBN = bookInDb.ISBN;
                book.GenreID = book.GenreID;
                book.NumberInStock = book.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}