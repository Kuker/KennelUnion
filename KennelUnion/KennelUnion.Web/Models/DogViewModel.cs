using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Web.Models
{
    public class DogViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Chip { get; set; }
    }
}
