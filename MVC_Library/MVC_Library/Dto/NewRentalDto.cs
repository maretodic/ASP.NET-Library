using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Dto
{
    public class NewRentalDto
    {
        public int MemberId { get; set; }
        public List<int> BookIds { get; set; }
    }
}