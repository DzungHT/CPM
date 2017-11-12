using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Repository.DTO
{
    public class UserLoginDTO
    {
        public class UserLoginInput
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class UserLoginOutput
        {
            public int UserID { get; set; }
            public string FullName { get; set; }
            public List<int> ListRole { get; set; }
            public List<int> ListMenu { get; set; }
        }
    }
}