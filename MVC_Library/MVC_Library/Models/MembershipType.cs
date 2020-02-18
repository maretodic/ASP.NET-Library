﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
    }
}