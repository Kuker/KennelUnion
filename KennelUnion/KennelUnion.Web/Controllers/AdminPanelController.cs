using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Web.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IRepository<News> _newsRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminPanelController(UserManager<IdentityUser> userManager, IRepository<News> newsRepository)
        {
            this._userManager = userManager;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(News model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var news = new News
            {
                Title = model.Title,
                Preview = model.Preview,
                Body = model.Body,
                Author = _userManager.GetUserAsync(HttpContext.User).Result,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            _newsRepository.Add(news);
            _newsRepository.Save();

            return RedirectToAction("BrowseNews","AdminPanel");

        }

        public IActionResult BrowseNews(int page = 1, int maxPerPage = 15)
        {
            ViewBag.PagesCount = (int)Math.Ceiling((decimal)_newsRepository.GetAll().Count()/maxPerPage);
            ViewBag.Page = page;
            ViewBag.MaxPerPage = maxPerPage;
            var news = _newsRepository.GetAll()
                .Include(x=>x.Author)
                .OrderByDescending(x=>x.UpdatedOn)
                .Skip((page - 1) * maxPerPage)
                .Take(maxPerPage);
            return View(news);
        }

        public IActionResult EditNews(int id = 0)
        {
            var news = _newsRepository.GetById(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        public IActionResult DeleteNews(int id = 0)
        {
            var news = _newsRepository.GetById(id);
            _newsRepository.Delete(news);
            _newsRepository.Save();
            return RedirectToAction("BrowseNews");
        }

        public IActionResult ShowNews(int id = 0)
        {
            var news = _newsRepository.GetById(id);
            return View(news);
        }
    }
}

