using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KennelUnion.Data.Entities
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Preview { get; set; }
        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        
        public IEnumerable<Comment> Comments { get; set; }

        public IdentityUser Author { get; set; }
    }
}
