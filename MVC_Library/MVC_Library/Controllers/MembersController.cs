using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_Library.Models;

namespace MVC_Library.Controllers
{
    public class MembersController : Controller
    {
        private ApplicationDbContext _context;
        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Members
        public ViewResult Index()
        {
            var members = _context.Members.Include(m => m.MembershipType).ToList();
            return View(members);
        }

        public ActionResult Details(int id)
        {
            var member = _context.Members.Include(m => m.MembershipType).SingleOrDefault(m => m.ID == id);
            if(member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }
    }
}