﻿using System;
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
        public IHttpActionResult GetBooks()
        {
            var books = _context.Books.Include(b => b.Genre).ToList().Select(Mapper.Map<Book, BookDto>);
            return Ok(books);
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