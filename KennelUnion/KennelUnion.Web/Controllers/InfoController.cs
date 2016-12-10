using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KennelUnion.Web.Controllers
{
    public class InfoController : Controller
    {
        private readonly IRepository<About> _aboutRepo;

        public InfoController(IRepository<About> aboutRepo)
        {
            _aboutRepo = aboutRepo;
        }

        public IActionResult About()
        {
            var about = _aboutRepo.GetAll();
            return View(about.Last());
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
