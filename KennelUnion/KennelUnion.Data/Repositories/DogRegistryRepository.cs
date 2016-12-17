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
    public class DogRegistryRepository : IRepository<DogRegistry>
    {
        private readonly DatabaseContext _db;

        public DogRegistryRepository(DatabaseContext db)
        {
            _db = db;
        }

        public DogRegistry GetById(int id)
        {
            return _db.DogRegistries.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<DogRegistry> GetAll()
        {
            return _db.DogRegistries;
        }

        public IQueryable<DogRegistry> FindBy(Expression<Func<DogRegistry, bool>> predicate)
        {
            return _db.DogRegistries.Where(predicate);
        }

        public void Add(DogRegistry item)
        {
            _db.DogRegistries.Add(item);
        }

        public void Edit(DogRegistry item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(DogRegistry item)
        {
            var registry = _db.DogRegistries.First(x => x.Id == item.Id);
            _db.DogRegistries.Remove(registry);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
