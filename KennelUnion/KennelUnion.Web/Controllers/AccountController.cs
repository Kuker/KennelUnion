using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace KennelUnion.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> loginManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> loginManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (!ModelState.IsValid)
                return View(obj);


            IdentityUser user = new IdentityUser();
            user.UserName = obj.UserName;
            user.Email = obj.Email;

            IdentityResult result = userManager.CreateAsync(user, obj.Password).Result;

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(obj);
            }

            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                {
                    ModelState.AddModelError("","Error while creating role!");
                    return View(obj);
                }
            }
            userManager.AddToRoleAsync(user, "NormalUser").Wait();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = loginManager.PasswordSignInAsync(obj.UserName, obj.Password, obj.RememberMe, false).Result;
                if (result.Succeeded)
                    return RedirectToAction("Index", "News");
                ModelState.AddModelError("", "Invalid login or password!");
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            loginManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "News");
        }

    }
}
