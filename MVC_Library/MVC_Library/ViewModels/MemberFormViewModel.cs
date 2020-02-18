using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Library.Models;

namespace MVC_Library.ViewModels
{
    public class MemberFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Member Member { get; set; }
    }
}