using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Article> Article { get; set; }
    }
}
