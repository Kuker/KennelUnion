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
        private int maxNewsPerPage { get; set; }

        public NewsController(IRepository<News> newsRepo)
        {
            _newsRepo = newsRepo;
            maxNewsPerPage = 10;
        }

        public IActionResult Index()
        {
            var news = _newsRepo.GetAll().OrderBy(x=>x.CreatedOn).Take(maxNewsPerPage);
            return View(news.ToList());
        }

        public IActionResult Show(int id)
        {
            var news = _newsRepo.GetById(id);
            return View(news);
        }
    }
}
