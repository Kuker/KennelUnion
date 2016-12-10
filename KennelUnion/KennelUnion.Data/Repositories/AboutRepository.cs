using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Data.Repositories
{
    public class AboutRepository : IRepository<About>
    {

        private readonly DatabaseContext _db;

        public AboutRepository(DatabaseContext db)
        {
            _db = db;
        }

        public About GetById(int id)
        {
            return _db.Abouts.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<About> GetAll()
        {
            return _db.Abouts;
        }

        public IQueryable<About> FindBy(Expression<Func<About, bool>> predicate)
        {
            return _db.Abouts.Where(predicate);
        }

        public void Add(About item)
        {
            _db.Abouts.Add(item);
        }

        public void Edit(About item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(About item)
        {
            var about = _db.Abouts.First(x => x.Id == item.Id);
            _db.Abouts.Remove(about);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
