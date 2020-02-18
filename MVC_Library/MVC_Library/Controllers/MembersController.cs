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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new MemberFormViewModel
            {
                Member = new Member(),
                MembershipTypes = membershipTypes
            };
            return View("MemberForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(b => b.ID == id);
            if (member == null)
            {
                return HttpNotFound();
            }

            var vm = new MemberFormViewModel
            {
                Member = member,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("MemberForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Member member)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MemberFormViewModel
                {
                    Member = member,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("MemberForm", viewModel);
            }

            if (member.ID == 0)
            {
                _context.Members.Add(member);
            }
            else
            {
                var memberInDb = _context.Members.SingleOrDefault(m => m.ID == member.ID);
                memberInDb.Name = member.Name;
                memberInDb.BirthDate = member.BirthDate;
                memberInDb.MembershipTypeID = member.MembershipTypeID;
                memberInDb.IsSubscribedToNewsletter = member.IsSubscribedToNewsletter;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}