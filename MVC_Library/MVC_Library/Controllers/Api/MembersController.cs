using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Library.Dto;
using MVC_Library.Models;
using System.Data.Entity;
using AutoMapper;

namespace MVC_Library.Controllers.Api
{
    public class MembersController : ApiController
    {
        private ApplicationDbContext _context;
        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/members
        [HttpGet]
        public IHttpActionResult GetMembers()
        {
            var members = _context.Members.Include(m => m.MembershipType).ToList().Select(Mapper.Map<Member, MemberDto>);
            return Ok(members);
        }

        //GET api/members/1
        [HttpGet]
        public IHttpActionResult GetMember(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.ID == id);
            if(member == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Member, MemberDto>(member));
        }

        //POST /api/members
        [HttpPost]
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var member = Mapper.Map<MemberDto, Member>(memberDto);
            _context.Members.Add(member);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + member.ID), memberDto);
        }

        //PUT /api/members/1
        [HttpPut]
        public IHttpActionResult UpdateMember(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var member = _context.Members.SingleOrDefault(m => m.ID == id);
            if(member == null)
            {
                return NotFound();
            }

            Mapper.Map(memberDto, member);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/members/1
        [HttpDelete]
        public IHttpActionResult DeleteMember(int id)
        {
            var memberInDB = _context.Members.SingleOrDefault(m => m.ID == id);
            if(memberInDB == null)
            {
                return NotFound();
            }

            _context.Members.Remove(memberInDB);
            _context.SaveChanges();
            return Ok();
        }
    }
}
