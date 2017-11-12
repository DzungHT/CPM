using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Repository.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string LoginName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string EmployeeCode { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? Status { get; set; }

        public int? NewID { get; set; }

        public DateTime? ChangePasswordDate { get; set; }

        public int? NeedChangePassword { get; set; }

        public string EncryptedPassword { get; set; }

        public string ActiveCode { get; set; }

        public DateTime? RequestDate { get; set; }
    }
}