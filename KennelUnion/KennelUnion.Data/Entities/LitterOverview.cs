using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Data.Entities
{
    public class LitterOverview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Breed { get; set; }
        public string Father { get; set; }
        public string FatherRegistrationNumber { get; set; }
        public string Mother { get; set; }
        public string MotherRegistrationNumber { get; set; }

        public DateTime MatingDate { get; set; }
        public DateTime BirthDate { get; set; }

        public string Description { get; set; }

        public IList<Pup> Pups { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
