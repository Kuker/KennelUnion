using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Data.Entities
{
    public class DogRegistry
    {
        public int Id { get; set; }
        public Breeder Breeder { get; set; }
        public Dog Dog { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsApproved { get; set; }
    }
}
