using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Data.Entities
{
    public class Pup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Chip { get; set; }
        public string Sex { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
