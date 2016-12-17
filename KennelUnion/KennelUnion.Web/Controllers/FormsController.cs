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
        private readonly IRepository<DogRegistry> _repo;

        public FormsController(IRepository<DogRegistry> repo)
        {
            _repo = repo;
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

            _repo.Add(dogRegistryModel);
            _repo.Save();

            return RedirectToAction("Index","News");
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
