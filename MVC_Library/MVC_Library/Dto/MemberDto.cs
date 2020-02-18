using MVC_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Library.Dto
{
    public class MemberDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeID { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
    }
}