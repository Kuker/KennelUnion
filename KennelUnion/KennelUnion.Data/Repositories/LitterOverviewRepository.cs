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
    public class LitterOverviewRepository : IRepository<LitterOverview>
    {

        private readonly DatabaseContext _db;

        public LitterOverviewRepository(DatabaseContext db)
        {
            _db = db;
        }

        public LitterOverview GetById(int id)
        {
            return _db.LitterOverviews.First(x => x.Id == id);
        }

        public IQueryable<LitterOverview> GetAll()
        {
            return _db.LitterOverviews;
        }

        public IQueryable<LitterOverview> FindBy(Expression<Func<LitterOverview, bool>> predicate)
        {
            return _db.LitterOverviews.Where(predicate);
        }

        public void Add(LitterOverview item)
        {
            _db.LitterOverviews.Add(item);
        }

        public void Edit(LitterOverview item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(LitterOverview item)
        {
            var litterOverview = _db.LitterOverviews.First(x => x.Id == item.Id);
            _db.LitterOverviews.Remove(litterOverview);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
