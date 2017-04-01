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
    public class BreederTipsRepository : IRepository<BreederTips>
    {
        private readonly DatabaseContext _db;

        public BreederTipsRepository(DatabaseContext db)
        {
            _db = db;
        }

        public BreederTips GetById(int id)
        {
            return _db.BreederTips.First(x => x.Id == id);
        }

        public IQueryable<BreederTips> GetAll()
        {
            return _db.BreederTips;
        }

        public IQueryable<BreederTips> FindBy(Expression<Func<BreederTips, bool>> predicate)
        {
            return _db.BreederTips.Where(predicate);
        }

        public void Add(BreederTips item)
        {
            _db.BreederTips.Add(item);
        }

        public void Edit(BreederTips item)
        {
            var dbItem = _db.BreederTips.First(x => x.Id == item.Id);

            _db.Entry(dbItem).State = EntityState.Modified;
        }

        public void Delete(BreederTips item)
        {
            var dbItem = _db.BreederTips.First(x => x.Id == item.Id);

            _db.BreederTips.Remove(dbItem);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
