using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Web.Models
{
    public class LitterOverviewViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Father { get; set; }
        [Required]
        public string FatherRegistrationNumber { get; set; }
        [Required]
        public string Mother { get; set; }
        [Required]
        public string MotherRegistrationNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MatingDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public IList<PupViewModel> Pups { get; set; }
    }
}
