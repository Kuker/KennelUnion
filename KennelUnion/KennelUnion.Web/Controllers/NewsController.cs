using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KennelUnion.Web.Properties.Controllers
{
    public class NewsController : Controller
    {
        private readonly IRepository<News> _newsRepo;

        public NewsController(IRepository<News> newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public IActionResult Index()
        {
            var news = _newsRepo.GetAll();
            return View(news.ToList());
        }
    }
}
