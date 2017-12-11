using CybertronFramework.Models;
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
            object[] parameters = new object[] { };
            foreach (PropertyInfo proK in proArrayK)
            {
                int i = 0;
                var propT = proArrayT.FirstOrDefault(x => x.Name.Equals(proK.Name));
                if (propT != null)
                {
                    object value = proK.GetValue(KObject);
                    Type type = proK.GetType();
                    if (type == typeof(int) && (int)value != 0)
                    {
                        condition += " AND t." + proK.Name + " = @value" + i.ToString();
                        parameters[i] = new SqlParameter("value" + i.ToString(), (int)value);
                        i++;
                    } else if (type == typeof(string) && value.ToString().Trim() != "")
                    {
                        condition += " AND LOWER(t." + proK.Name + ") like @value" + i.ToString();
                        parameters[i] = new SqlParameter("value" + i.ToString(), "%" + value.ToString().Trim().ToLower() + "%");
                        i++;
                    }
                }
            }
            result = set.SqlQuery( query + condition + strOrder, parameters).ToList();
            return result;
        }
        
        public CybertronPagedList<T> Search<T>(int page, int recordPerPage,string sql, string orders, params SqlParameter[] parameters) where T:class
        {
            DbSet<T> set = db.Set<T>();
            int offset = (page - 1) * recordPerPage;

            string commandFormat = @"select * from ( {0} ) tabl {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY";

            string orderClause = "";
            string[] ordersArr = orders.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (orders != null || orders.Length > 0)
            {
                for (int i = 0; i < ordersArr.Length; i++)
                {
                    ordersArr[0] = "tabl." + ordersArr[0].Trim();
                }
                orderClause = "ORDER BY " + string.Join(",", ordersArr);
            }
            

            string command = string.Format(commandFormat,
                                            sql, 
                                            orderClause,
                                            offset, 
                                            recordPerPage
                                            );
            List<T> data = set.SqlQuery(command, parameters).ToList();
            int recordsTotal = db.Database.SqlQuery<int>(string.Format("SELECT COUNT(*) as recordsTotal FROM {0}", typeof(T).Name)).FirstOrDefault<int>();

            List<SqlParameter> parameters2 = new List<SqlParameter>();
            foreach (var item in parameters)
            {
                parameters2.Add(new SqlParameter(item.ParameterName, item.Value));
            }
            int recordsFiltered = db.Database.SqlQuery<int>(string.Format("SELECT COUNT(*) as recordsFiltered FROM ({0}) tabl", sql), parameters2.ToArray()).FirstOrDefault<int>();

            var result = new CybertronPagedList<T>(page, recordsTotal, recordsFiltered, data);
            return result;
        }

        public string MakeFilterString<T>(string field, T value, ref List<SqlParameter> parameters)
        {
            string str = "";
            if(value != null)
            {
                Type type = typeof(T);
                object sqlValue = default(T);
                string sqlOperator = "=";
                if (type == typeof(int) || type == typeof(int?))
                {
                    sqlOperator = "=";
                    sqlValue = value;
                }
                else if (type == typeof(string) && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    sqlOperator = "LIKE";
                    sqlValue = string.Format("%{0}%", value);
                }

                str = string.Format(" AND {0} {1} @value{2} ", field, sqlOperator, parameters.Count);
                parameters.Add(new SqlParameter("value" + parameters.Count, sqlValue));
            }
            return str;
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