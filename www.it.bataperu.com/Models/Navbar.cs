﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace www.it.bataperu.com.Models
{
    public class Navbar
    {
        public int Id { get; set; }
        public string nameOption { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public string area { get; set; }
        public string imageClass { get; set; }
        public string activeli { get; set; }
        public bool estatus { get; set; }
    }
}