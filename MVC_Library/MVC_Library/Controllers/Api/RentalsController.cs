using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using MVC_Library.Dto;
using MVC_Library.Models;

namespace MVC_Library.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/rentals
        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            var rentalsQuery = _context.Rentals.Include(r => r.Member).Include(r => r.Book);
            var rentalsDto = rentalsQuery.ToList().Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalsDto);
        }

        //GET /api/rentals/1
        [HttpGet]
        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.ID == id);
            if(rental == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        [HttpPut]
        public IHttpActionResult UpdateRental(int id)
        {
            var rental = _context.Rentals.Include(r => r.Member).Include(r => r.Book).SingleOrDefault(r => r.ID == id);

            rental.DateReturned = DateTime.Now;
            rental.Book.NumberAvailable++;
            _context.SaveChanges();
            return Ok();
        }
    }
}
