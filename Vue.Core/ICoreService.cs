using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vue.Core
{
   public interface ICoreService<T> where T:CoreEntity
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        List<T> GetAll();
        List<T> GetByExp(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
        T GetById(int id);
    }
}
