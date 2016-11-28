using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Data.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private readonly DatabaseContext _db;

        public NewsRepository(DatabaseContext db)
        {
            _db = db;
        }

        public News GetById(int id)
        {
            return _db.NewsSet.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<News> GetAll()
        {
            return _db.NewsSet;
        }

        public IQueryable<News> FindBy(Expression<Func<News, bool>> predicate)
        {
            return _db.NewsSet.Where(predicate);
        }

        public void Add(News item)
        {
            _db.NewsSet.Add(item);
        }

        public void Edit(News item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(News item)
        {
            var news = _db.NewsSet.First(x=>x.Id == item.Id);
            _db.NewsSet.Remove(news);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}