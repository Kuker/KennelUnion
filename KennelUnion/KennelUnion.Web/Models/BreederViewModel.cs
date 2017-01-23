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
        [PolishRequired]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [PolishRequired]
        [Display(Name = "Nazwisko")]
        public string Lastname { get; set; }
        [PolishRequired]
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [PolishRequired]
        [Display(Name = "Poczta")]
        public string Post { get; set; }
        [PolishRequired]
        [Display(Name = "Miejscowość")]
        public string Location { get; set; }
        [PolishRequired]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }
        [PolishRequired]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Dog Dog { get; set; }
    }
}
