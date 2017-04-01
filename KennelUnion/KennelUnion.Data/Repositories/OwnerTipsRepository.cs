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
    public class OwnerTipsRepository : IRepository<OwnerTips>
    {
        private readonly DatabaseContext _db;

        public OwnerTipsRepository(DatabaseContext db)
        {
            _db = db;
        }

        public OwnerTips GetById(int id)
        {
            return _db.OwnerTips.First(x => x.Id == id);
        }

        public IQueryable<OwnerTips> GetAll()
        {
            return _db.OwnerTips;
        }

        public IQueryable<OwnerTips> FindBy(Expression<Func<OwnerTips, bool>> predicate)
        {
            return _db.OwnerTips.Where(predicate);
        }

        public void Add(OwnerTips item)
        {
            _db.OwnerTips.Add(item);
        }

        public void Edit(OwnerTips item)
        {
            var dbItem = _db.OwnerTips.First(x => x.Id == item.Id);

            _db.Entry(dbItem).State = EntityState.Modified;
        }

        public void Delete(OwnerTips item)
        {
            var dbItem = _db.OwnerTips.First(x => x.Id == item.Id);

            _db.OwnerTips.Remove(dbItem);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
