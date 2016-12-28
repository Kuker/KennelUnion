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
    public class ContactRepository : IRepository<Contact>
    {
        private readonly DatabaseContext _db;

        public ContactRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Contact GetById(int id)
        {
            return _db.Contacts.First(x => x.Id == id);
        }

        public IQueryable<Contact> GetAll()
        {
            return _db.Contacts;
        }

        public IQueryable<Contact> FindBy(Expression<Func<Contact, bool>> predicate)
        {
            return _db.Contacts.Where(predicate);
        }

        public void Add(Contact item)
        {
            _db.Contacts.Add(item);
        }

        public void Edit(Contact item)
        {
            var contact = _db.Contacts.First(x => x.Id == item.Id);

            _db.Entry(contact).State = EntityState.Modified;
        }

        public void Delete(Contact item)
        {
            var contact = _db.Contacts.First(x => x.Id == item.Id);

            _db.Contacts.Remove(contact);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
