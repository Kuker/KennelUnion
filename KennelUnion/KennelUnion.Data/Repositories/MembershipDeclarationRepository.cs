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
    public class MembershipDeclarationRepository : IRepository<MembershipDeclaration>
    {

        private readonly DatabaseContext _db;

        public MembershipDeclarationRepository(DatabaseContext db)
        {
            _db = db;
        }

        public MembershipDeclaration GetById(int id)
        {
            return _db.MembershipDeclarations.First(x => x.Id == id);
        }

        public IQueryable<MembershipDeclaration> GetAll()
        {
            return _db.MembershipDeclarations;
        }

        public IQueryable<MembershipDeclaration> FindBy(Expression<Func<MembershipDeclaration, bool>> predicate)
        {
            return _db.MembershipDeclarations.Where(predicate);
        }

        public void Add(MembershipDeclaration item)
        {
            _db.MembershipDeclarations.Add(item);
        }

        public void Edit(MembershipDeclaration item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(MembershipDeclaration item)
        {
            var declaration = _db.MembershipDeclarations.First(x => x.Id == item.Id);
            _db.MembershipDeclarations.Remove(declaration);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
