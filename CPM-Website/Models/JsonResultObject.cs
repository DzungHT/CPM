using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Models
{
    public class JsonResultObject
    {
        public bool IsSuccess { get; set; }
        public object Value { get; set; }
        public string Message { get; set; }
    }
}