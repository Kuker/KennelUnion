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
        private readonly IRepository<History> _historyRepo;

        public InfoController(IRepository<About> aboutRepo, IRepository<History> historyRepo)
        {
            _aboutRepo = aboutRepo;
            _historyRepo = historyRepo;
        }

        public IActionResult About()
        {
            var about = _aboutRepo.GetAll();
            return View(about.Last());
        }

        public IActionResult History()
        {
            var history = _historyRepo.GetAll();
            return View(history.Last());
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
