using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public abstract class BaseBusiness<TDbContext> : IDisposable where TDbContext : DbContext, new()
    {
        protected TDbContext db;

        public BaseBusiness()
        {
            db = new TDbContext();
        }

        protected void Save<T>(T entity) where T : class
        {
            
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        protected void Update<T>(T entity) where T : class
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected void Delete<T>(int id) where T : class
        {
            DbSet<T> set = db.Set<T>();
            T entity = set.Find(id);
            if (entity != null)
            {
                set.Remove(entity);
                db.SaveChanges();
            }
        }

        protected void Delete<T>(T entity) where T : class
        {
            DbSet<T> set = db.Set<T>();
            if (entity != null)
            {
                set.Remove(entity);
                db.SaveChanges();
            }
        }

        protected List<T> GetAll<T>() where T :class
        {
            return db.Set<T>().ToList();
        }

        protected T Get<T>(params object[] ids) where T: class
        {
            DbSet<T> set = db.Set<T>();
            return set.Find(ids);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}