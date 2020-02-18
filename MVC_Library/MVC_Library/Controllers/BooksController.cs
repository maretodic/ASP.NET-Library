using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_Library.Models;

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
    }
}