using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CPM_Website.CybertronFramework.Common
{
    public static class Constants
    {
        public static string API_BASE_ADRESS { get{ return ConfigurationManager.AppSettings["ApiBaseAdress"]; } }
    }
}