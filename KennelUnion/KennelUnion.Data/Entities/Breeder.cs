using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KennelUnion.Data.Entities
{
    public class Breeder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Post { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Dog Dog { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
