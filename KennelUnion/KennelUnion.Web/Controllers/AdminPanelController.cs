using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KennelUnion.Web.Controllers
{
    [Authorize]
    public class AdminPanelController : Controller
    {
        private readonly IRepository<News> _newsRepository;
        private readonly IRepository<DogRegistry> _dogRegistryRepository;
        private readonly IRepository<LitterOverview> _litterOverviewRepository;
        private readonly IRepository<MembershipDeclaration> _membershipDeclarationRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminPanelController(UserManager<IdentityUser> userManager, IRepository<News> newsRepository, IRepository<DogRegistry> dogRegistryRepository, IRepository<LitterOverview> litterOverviewRepository, IRepository<MembershipDeclaration> membershipDeclarationRepository)
        {
            this._userManager = userManager;
            _newsRepository = newsRepository;
            _dogRegistryRepository = dogRegistryRepository;
            _litterOverviewRepository = litterOverviewRepository;
            _membershipDeclarationRepository = membershipDeclarationRepository;
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

        public IActionResult BrowseDogRegistries(int page = 1, int maxPerPage = 15)
        {
            ViewBag.PagesCount = (int) Math.Ceiling((decimal) _dogRegistryRepository.GetAll().Count()/maxPerPage);
            ViewBag.Page = page;
            ViewBag.MaxPerPage = maxPerPage;
            var registries = _dogRegistryRepository.GetAll()
                .Include(x => x.Breeder)
                .Include(x => x.Dog)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1)*maxPerPage)
                .Take(maxPerPage);
            return View(registries);
        }

        public IActionResult AcceptRegistry(int id = 0)
        {
            var registry = _dogRegistryRepository.GetById(id);
            registry.IsApproved = true;
            _dogRegistryRepository.Edit(registry);
            _dogRegistryRepository.Save();
            return RedirectToAction("BrowseDogRegistries");
        }

        public IActionResult BrowseLitterOverviews(int page = 1, int maxPerPage = 15)
        {
            ViewBag.PagesCount = (int) Math.Ceiling((decimal) _litterOverviewRepository.GetAll().Count()/maxPerPage);
            ViewBag.Page = page;
            ViewBag.MaxPerPage = maxPerPage;
            var overviews = _litterOverviewRepository.GetAll()
                .Include(x => x.Pups)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1)*maxPerPage)
                .Take(maxPerPage);
            return View(overviews);
        }

        public IActionResult ShowLitterOverview(int id = 0)
        {
            var overview = _litterOverviewRepository.FindBy(x=>x.Id == id)
                .Include(x=>x.Pups)
                .FirstOrDefault();

            return View(overview);
        }

        public IActionResult AcceptOverview(int id = 0)
        {
            var overview = _litterOverviewRepository.GetById(id);
            overview.IsApproved = true;
            _litterOverviewRepository.Edit(overview);
            _litterOverviewRepository.Save();
            return RedirectToAction("BrowseLitterOverviews");
        }

        public IActionResult BrowseMembershipDeclarations(int page = 1, int maxPerPage = 15)
        {
            ViewBag.PagesCount = (int) Math.Ceiling((decimal) _membershipDeclarationRepository.GetAll().Count()/maxPerPage);
            ViewBag.Page = page;
            ViewBag.MaxPerPage = maxPerPage;
            var declarations = _membershipDeclarationRepository.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1)*maxPerPage)
                .Take(maxPerPage);
            return View(declarations);
        }

        public IActionResult AcceptMembershipDeclaration(int id = 0)
        {
            var declaration = _membershipDeclarationRepository.GetById(id);
            declaration.IsApproved = true;
            _membershipDeclarationRepository.Edit(declaration);
            _membershipDeclarationRepository.Save();
            return RedirectToAction("BrowseMembershipDeclarations");
        }
    }
}

