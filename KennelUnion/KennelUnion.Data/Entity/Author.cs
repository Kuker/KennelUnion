using System;
using System.Collections.Generic;
using System.Text;

namespace KennelUnion.Data.Entity
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
