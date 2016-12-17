using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Data.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public string Color { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Chip { get; set; }
    }
}
