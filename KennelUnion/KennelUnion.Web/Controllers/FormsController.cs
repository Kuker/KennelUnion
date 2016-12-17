using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KennelUnion.Web.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult DogRegistry()
        {
            return View();
        }

        public IActionResult MembershipDeclaration()
        {
            return View();
        }

        public IActionResult DogOverview()
        {
            return View();
        }
    }
}
