using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class ApplicationBusiness
    {
        dbContext db = new dbContext();

        public bool save(Application obj)
        {
            using (db)
            {
                db.Applications.Add(obj);
                db.SaveChanges();
            }
            return obj.ApplicationID > 0;
        }

        public bool update(Application obj)
        {
            using (db)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            return obj.ApplicationID > 0;
        }

        public bool delete(int id)
        {
            Application obj = db.Applications.Find(id);
            if (obj != null)
            {
                db.Applications.Remove(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Application> getList()
        {
            using (db)
            {
                return db.Applications.ToList();
            }
        }

        public Application getObject(int id)
        {
            using (db)
            {
                return db.Applications.Find(id);
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}