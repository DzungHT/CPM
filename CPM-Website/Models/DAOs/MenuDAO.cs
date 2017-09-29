using CPM_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace CPM_Website.Models.DAOs
{
    public class MenuDAO
    {
        private dbContext db;
        public MenuDAO()
        {
            db = new dbContext();
        }

        public List<Menu> LoadMenu(IPrincipal user)
        {
            User acc = db.Users.SingleOrDefault(x => x.LoginName == user.Identity.Name);
            List<Menu> result = new List<Menu>();
            if(acc != null)
            {
                result = db.Menus.SqlQuery("spGetMenuByAccount @AccountID", new SqlParameter("AccountID", acc.UserID)).ToList();
            }
            return result;
        }
    }
}