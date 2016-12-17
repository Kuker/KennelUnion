using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;

namespace KennelUnion.Web.Models
{
    public class BreederViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Post { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public Dog Dog { get; set; }
    }
}
