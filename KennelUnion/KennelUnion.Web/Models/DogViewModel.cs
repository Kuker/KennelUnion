using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Web.Models
{
    public class PolishRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            ErrorMessage = "Uzupełnij pole {0}";
            return base.IsValid(value);
        }
    }

    public class DogViewModel
    {
        [PolishRequired, Display(Name = "Nazwa")]
        public string Name { get; set; }

        [PolishRequired, Display(Name = "Rasa")]
        public string Breed { get; set; }

        [Display(Name = "Imię ojca")]
        public string Father { get; set; }

        [Display(Name = "Imię matki")]
        public string Mother { get; set; }
        [PolishRequired]
        [Display(Name = "Umaszczenie")]
        public string Color { get; set; }
        [PolishRequired]
        [Display(Name = "Płeć")]
        public string Sex { get; set; }
        [PolishRequired]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime BirthDate { get; set; }
        [PolishRequired]
        [Display(Name = "Nazwa chipa")]
        public string Chip { get; set; }
    }
}
