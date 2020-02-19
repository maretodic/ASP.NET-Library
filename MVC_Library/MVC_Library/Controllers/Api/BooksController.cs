using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Library.Models;
using MVC_Library.Dto;
using AutoMapper;
using System.Data.Entity;

namespace MVC_Library.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/books
        [HttpGet]
        public IHttpActionResult GetBooks(string query = null)
        {
            var booksQuery = _context.Books.Include(b => b.Genre);
            if (!String.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Title.Contains(query));
            }
            var booksDto = booksQuery.ToList().Select(Mapper.Map<Book, BookDto>);
            return Ok(booksDto);
        }

        //GET /api/books/1
        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.ID == id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        //POST /api/books
        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + book.ID), bookDto);
        }

        //PUT /api/books/1
        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _context.Books.SingleOrDefault(b => b.ID == id);
            if(book == null)
            {
                return NotFound();
            }

            Mapper.Map(bookDto, book);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/books/1
        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.ID == id);
            if(book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
