using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CMP_Servive.Helper
{
    public static class Constants
    {
        public static string ENCRYPT_KEY { get { return ConfigurationManager.AppSettings["kljijsa"]; } }

        public static class AUTHENTICATION
        {
            public static string ROLE_USER = "USER";
            public static string ROLE_ADMINISTRATOR = "ADMINISTRATOR";
        }
    }
}