using CMP_Servive.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Models.DTO
{
    public class UserLoginDTO
    {

    }

    public class UserLoginOutput
    {
        #region Entity's properties
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public bool? NeedChangePassword { get; set; }
        public DateTime? ChangePasswordTime { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Status { get; set; }
        public string ActiveCode { get; set; }
        public DateTime? RequestDate { get; set; }
        #endregion

        #region Extra properties
        public List<string> Roles { get; set; }
        #endregion


    }

    public class UserLoginInput
    {
        public string UserName { get; set; }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value.ToMD5(); }
        }

        public int ApplicationID { get; set; }
    }
}