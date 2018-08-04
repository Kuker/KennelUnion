using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Configuration;
using KennelUnion.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Article> Article { get; set; }

        private readonly IDbConfiguration _dbConfiguration;

        public DatabaseContext(IDbConfiguration dbConfiguration)
        {
            this._dbConfiguration = dbConfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConfiguration.ConnectionString);
        }
    }
}
