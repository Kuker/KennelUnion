using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using KennelUnion.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Web.Properties.Controllers
{
    public class NewsController : Controller
    {
        private readonly IRepository<News> _newsRepo;

        public NewsController(IRepository<News> newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public IActionResult Index(int page = 1, int maxPerPage = 15)
        {
            ViewBag.PagesCount = (int) Math.Ceiling((decimal) _newsRepo.GetAll().Count()/maxPerPage);
            ViewBag.Page = page;
            ViewBag.MaxPerPage = maxPerPage;
            var news = _newsRepo.GetAll()
                .Include(x=>x.Author)
                .OrderByDescending(x=>x.CreatedOn)
                .Skip((page - 1) * maxPerPage)
                .Take(maxPerPage);
            return View(news.ToList());
        }

        public IActionResult Show(int id)
        {
            var news = _newsRepo.GetById(id);
            return View(news);
        }

        [Authorize]
        public IActionResult Edit(int id = 0)
        {
            var news = _newsRepo.GetById(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, NewsViewModel news)
        {
            if (!ModelState.IsValid)
                return View(news);

            var newsModel = _newsRepo.GetById(id);
            if (newsModel != null)
            {
                newsModel.Body = news.Body;
                newsModel.Title = news.Title;
                newsModel.Preview = news.Preview;
                newsModel.UpdatedOn = DateTime.Now;
            }

            _newsRepo.Edit(newsModel);
            _newsRepo.Save();

            return RedirectToAction("Show","News", new {id=newsModel.Id});

        }
    }
}
