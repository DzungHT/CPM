using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Models
{
    public class MenuViewModel
    {
        public string Name { get; set; }
        public string MenuCss { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public List<MenuViewModel> childs { get; set; }
    }
}