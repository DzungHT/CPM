using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Models.DTO
{
    public class UserRoleDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<int> Selection { get; set; }
    }
}