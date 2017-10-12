using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class MenuBusiness
    {
        dbContext db = new dbContext();

        public bool save(Menu obj)
        {
            using (db)
            {
                db.Menus.Add(obj);
                db.SaveChanges();
            }
            return obj.ApplicationID > 0;
        }

        public bool update(Menu obj)
        {
            using (db)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            return obj.MenuID > 0;
        }

        public bool delete(int id)
        {
            Menu obj = db.Menus.Find(id);
            if (obj != null)
            {
                db.Menus.Remove(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> getList()
        {
            using (db)
            {
                return db.Menus.ToList();
            }
        }

        public Menu getObject(int id)
        {
            using (db)
            {
                return db.Menus.Find(id);
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}