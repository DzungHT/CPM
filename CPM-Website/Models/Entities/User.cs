using System;
using System.Collections.Generic;

namespace CPM_Website.Models
{
    public partial class User
    {
        public int UserID { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public bool? NeedChangePassword { get; set; }

        public DateTime? ChangePasswordTime { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? Status { get; set; }

        public string ActiveCode { get; set; }

        public DateTime? RequestDate { get; set; }

        public List<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }

    }
}
