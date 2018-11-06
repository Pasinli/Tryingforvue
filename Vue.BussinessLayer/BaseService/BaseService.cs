using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vue.Core;
using Vue.DataLayer;

namespace Vue.BussinessLayer.Services
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private NorthwindEntities db;
        protected DbSet<T> table;

        public BaseService()
        {
            db = new NorthwindEntities();
        }
        
        public void Add(T item)
        {

            db.Set<T>().Add(item);
            Save();
        }

        public void Update(T item)
        {
            T data = GetById(item.Id);
            DbEntityEntry entry = db.Entry(data);
            entry.CurrentValues.SetValues(item);
            Save();

        }

        public void Delete(T item)
        {
            table.Remove(item);
            Save();
             
        }

      
        

        public List<T> GetAll() => db.Set<T>().ToList();
       

        public List<T> GetByExp(Expression<Func<T, bool>> exp)
        {
           return db.Set<T>().Where(exp).ToList();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T GetById(int id)    
        {
            return db.Set<T>().Find(id);
        }
    }
}
