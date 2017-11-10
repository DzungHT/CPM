using CMP_Servive.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class MenuBusiness : BaseBusiness<dbContext>
    {
        public bool AddRole(int roleId, List<int> lstMenuId)
        {
            db.RoleMenus.AddRange(
                    lstMenuId.Select(x=> new RoleMenu { MenuID = x, RoleID = roleId, IsActive = 1 })
                );
            db.SaveChanges();
            return true;
        }
        public List<Menu> GetMenuByUser(int userId)
        {
            var result = from ur in db.UserRoles
                         join rm in db.RoleMenus on ur.RoleID equals rm.RoleID
                         join m in db.Menus on rm.MenuID equals m.MenuID
                         where ur.UserID == userId
                         select m;
            return result.ToList();
        }
    }
}