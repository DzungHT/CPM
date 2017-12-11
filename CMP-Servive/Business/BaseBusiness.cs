using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CMP_Servive.Business
{
    public abstract class BaseBusiness<TDbContext> : IDisposable where TDbContext : DbContext, new()
    {
        protected TDbContext db;

        public BaseBusiness()
        {
            db = new TDbContext();
            db.Configuration.LazyLoadingEnabled = false;
        }

        public void Save<T>(T entity) where T : class
        {
            
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete<T>(int id) where T : class
        {
            DbSet<T> set = db.Set<T>();
            T entity = set.Find(id);
            if (entity != null)
            {
                set.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            DbSet<T> set = db.Set<T>();
            if (entity != null)
            {
                set.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<T> GetAll<T>() where T :class
        { 
            return db.Set<T>().ToList();
        }

        public T Get<T>(params object[] ids) where T: class
        {
            DbSet<T> set = db.Set<T>();
            return set.Find(ids);
        }

        public List<T> FindByProperty<T>(string propertyName, Object value, string order) where T: class
        {
            DbSet<T> set = db.Set<T>();
            List<T> result = new List<T>();
            string query = " SELECT * FROM " + typeof(T).Name + " t WHERE t." + propertyName + (value == null ? " IS NULL " : " = @value ") + (!String.IsNullOrEmpty(order) ? " ORDER BY " + order : "");
            result = set.SqlQuery(query, new SqlParameter("value",value)).ToList();
            return result;
        }

        public List<T> FindByProperty<T,K>(K KObject, string order) where T : class
        {
            DbSet<T> set = db.Set<T>();
            List<T> result = new List<T>();
            var proArrayT = typeof(T).GetProperties();
            var proArrayK = typeof(K).GetProperties();
            string query = " SELECT * FROM " + typeof(T).Name + " t WHERE 1=1";
            string condition = "";
            string strOrder = (!String.IsNullOrEmpty(order) ? " ORDER BY " + order : "");
            object[] parameters = new object[100];
            int i = 0;
            foreach (PropertyInfo proK in proArrayK)
            {
                var propT = proArrayT.FirstOrDefault(x => x.Name.Equals(proK.Name));
                if (propT != null)
                {
                    object value = proK.GetValue(KObject);
                    Type type = proK.PropertyType;
                    if (type == typeof(Int32) && (int)value != 0)
                    {
                        condition += " AND t." + proK.Name + " = {" + i.ToString() + "}";
                        parameters[i] = (int)value;
                        i++;
                    } else if (type == typeof(String) && value.ToString().Trim() != "")
                    {
                        condition += " AND LOWER(t." + proK.Name + ") like {" + i.ToString() + "}";
                        parameters[i] ="%" + value.ToString().Trim().ToLower() + "%";
                        i++;
                    }
                }
            }
            result = set.SqlQuery( query + condition + strOrder, parameters).ToList();
            return result;
        }

        public TDbContext getDbContext() {
            return db;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}