using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;

namespace KennelUnion.Web.Models
{
    public class DogRegistryViewModel
    {
        [Required]
        public BreederViewModel Breeder { get; set; }
        [Required]
        public DogViewModel Dog { get; set; }
    }
}
