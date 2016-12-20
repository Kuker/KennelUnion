using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using KennelUnion.Data.Repositories;
using KennelUnion.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KennelUnion.Web.Controllers
{
    public class FormsController : Controller
    {
        private readonly IRepository<DogRegistry> _dogRegistryRepo;
        private readonly IRepository<LitterOverview> _litterOverviewRepo;

        public FormsController(IRepository<DogRegistry> dogRegistryRepo, IRepository<LitterOverview> litterOverviewRepo)
        {
            _dogRegistryRepo = dogRegistryRepo;
            _litterOverviewRepo = litterOverviewRepo;
        }

        public IActionResult DogRegistry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DogRegistry(DogRegistryViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var dogRegistryModel = new DogRegistry();

            //TODO : Refactor - use automapper
            dogRegistryModel.Breeder = new Breeder
            {
                Email = model.Breeder.Email,
                Lastname = model.Breeder.Lastname,
                Location = model.Breeder.Location,
                Name = model.Breeder.Name,
                PhoneNumber = model.Breeder.PhoneNumber,
                Post = model.Breeder.Post,
                Street = model.Breeder.Street
            };
            dogRegistryModel.Dog = new Dog()
            {
                BirthDate = model.Dog.BirthDate,
                Breed = model.Dog.Breed,
                Chip = model.Dog.Chip,
                Color = model.Dog.Color,
                Mother = model.Dog.Mother,
                Father = model.Dog.Father,
                Name = model.Dog.Name,
                Sex = model.Dog.Sex
            };
            dogRegistryModel.CreatedOn = DateTime.Now;

            dogRegistryModel.Breeder.Dog = dogRegistryModel.Dog;

            _dogRegistryRepo.Add(dogRegistryModel);
            _dogRegistryRepo.Save();

            return RedirectToAction("Index","News");
        }

        public IActionResult MembershipDeclaration()
        {
            return View();
        }

        public IActionResult LitterOverview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LitterOverview(LitterOverviewViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var litterOverview = new LitterOverview();

            litterOverview.BirthDate = model.BirthDate;
            litterOverview.Breed = model.Breed;
            litterOverview.CreatedOn = DateTime.Now;
            litterOverview.Description = model.Description;
            litterOverview.Father = model.Father;
            litterOverview.FatherRegistrationNumber = model.FatherRegistrationNumber;
            litterOverview.MatingDate = model.MatingDate;
            litterOverview.Mother = model.Mother;
            litterOverview.MotherRegistrationNumber = model.MotherRegistrationNumber;
            litterOverview.Name = model.Name;
            litterOverview.Owner = model.Owner;

            litterOverview.Pups = new List<Pup>();
            for (var i = 0; i < 8; i++)
            {
                var pup = new Pup
                {
                    Chip = model.Pups[i].Chip,
                    Color = model.Pups[i].Color,
                    CreatedOn = DateTime.Now,
                    Name = model.Pups[i].Name,
                    Sex = model.Pups[i].Sex
                };
                litterOverview.Pups.Add(pup);
            }

            _litterOverviewRepo.Add(litterOverview);
            _litterOverviewRepo.Save();

            return RedirectToAction("Index","News");
        }
    }
}
