using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Web.Models
{
    public class MembershipDeclarationViewModel
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

        [Required]
        [DataType(DataType.Currency)]
        public string Contribution { get; set; }

        [Required]
        public string Nickname1 { get; set; }
        [Required]
        public string Nickname2 { get; set; }
        [Required]
        public string Nickname3 { get; set; }
    }
}
