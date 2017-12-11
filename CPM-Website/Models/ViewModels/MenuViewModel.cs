﻿using CybertronFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Models
{
    public class MenuViewModel
    {
        public int? MenuID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ApplicationID { get; set; }
        public DataTableRequest DataTable { get; set; }
    }
}