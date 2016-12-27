using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennelUnion.Web.Models
{
    public class NewsViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Preview { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
