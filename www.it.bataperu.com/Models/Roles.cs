﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace www.it.bataperu.com.Models
{
    public class Roles
    {
        public int rowid { get; set; }
        public int idUser { get; set; }
        public int idMenu { get; set; }
        public bool status { get; set; }
    }
}