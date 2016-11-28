using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T item);
        void Edit(T item);
        void Delete(T item);
        void Save();
    }
}
