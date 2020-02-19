using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.Models;
using System.Data.Entity;

namespace MVC_Library.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult GetRentals()
        {
            return View("List");
        }

        public void ReturnRental(int id)
        {
            var rental = _context.Rentals.Include(r => r.Member).Include(r => r.Book).SingleOrDefault(r => r.ID == id);

            rental.DateReturned = DateTime.Now;
            rental.Book.NumberAvailable++;
            _context.SaveChanges();
        }
    }
}