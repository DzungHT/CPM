using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class RoleBusiness
    {
        dbContext db = new dbContext();

        public bool save(Role obj)
        {
            using (db)
            {
                db.Roles.Add(obj);
                db.SaveChanges();
            }
            return obj.RoleID > 0;
        }

        public bool update(Role obj)
        {
            using (db)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            return obj.RoleID > 0;
        }

        public bool delete(int id)
        {
            Role obj = db.Roles.Find(id);
            if (obj != null)
            {
                db.Roles.Remove(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Role> getList()
        {
            using (db)
            {
                return db.Roles.ToList();
            }
        }

        public Role getObject(int id)
        {
            using (db)
            {
                return db.Roles.Find(id);
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}