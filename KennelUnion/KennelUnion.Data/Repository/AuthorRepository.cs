using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Context;
using KennelUnion.Data.Entity;

namespace KennelUnion.Data.Repository
{
    public class AuthorRepository
    {
        private readonly DatabaseContext _dbContext;

        public AuthorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Author GetById(Guid id)
        {
            return _dbContext.Author.FirstOrDefault(a => a.Id == id);
        }
    }
}
