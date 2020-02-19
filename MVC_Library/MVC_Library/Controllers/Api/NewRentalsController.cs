using MVC_Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using MVC_Library.Models;
using System.Web.Http;

namespace MVC_Library.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var member = _context.Members.Single(c => c.ID == newRentalDto.MemberId);

            var books = _context.Books.Where(m => newRentalDto.BookIds.Contains(m.ID)).ToList();

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                book.NumberAvailable--;

                var rental = new Rental
                {
                    Member = member,
                    Book = book,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
