using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Data.Repositories
{
    public class HistoryRepository : IRepository<History>
    {
        private readonly DatabaseContext _db;

        public HistoryRepository(DatabaseContext db)
        {
            _db = db;
        }

        public History GetById(int id)
        {
            return _db.Histories.First(x => x.Id == id);
        }

        public IQueryable<History> GetAll()
        {
            return _db.Histories;
        }

        public IQueryable<History> FindBy(Expression<Func<History, bool>> predicate)
        {
            return _db.Histories.Where(predicate);
        }

        public void Add(History item)
        {
            _db.Histories.Add(item);
        }

        public void Edit(History item)
        {
            var history = _db.Histories.First(x => x.Id == item.Id);
            _db.Entry(history).State = EntityState.Modified;
        }

        public void Delete(History item)
        {
            var history = _db.Histories.First(x => x.Id == item.Id);
            _db.Histories.Remove(history);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
