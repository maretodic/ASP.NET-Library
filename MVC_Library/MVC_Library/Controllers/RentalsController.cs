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

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult GetRentals()
        {
            return View("List");
        }

    }
}