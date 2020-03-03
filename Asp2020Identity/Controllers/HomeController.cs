using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp2020Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Asp2020Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Asp2020Identity.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext database;
        UserManager<IdentityUser> usermanager;
        RoleManager<IdentityRole> rolemanager;

        public HomeController(ApplicationDbContext db,
            UserManager<IdentityUser> um,
            RoleManager<IdentityRole> rm)
        {
            database = db;
            usermanager = um;
            rolemanager = rm;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateTodo()
        {
            return View();
        }

        public async Task<IActionResult> Delegate()
        {
            IdentityRole adminrole = new IdentityRole()
            {
                Name = "Admins"
            };

            await rolemanager.CreateAsync(adminrole);

            var firstuser = usermanager.Users.First();

            await usermanager.AddToRoleAsync(firstuser, "Admins");

            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "Admins")]
        public IActionResult Admin()
        {
            return View(database.Todos);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todo t)
        {
            //egyéb jellemzők a néven kívül
            t.CreationTime = DateTime.Now;
            t.Id = Guid.NewGuid().ToString();

            //token
            var myself = this.User;

            //IdentityUser objektum lekérés
            IdentityUser current =
                await usermanager.GetUserAsync(myself);

            t.UserId = current.Id;

            database.Todos.Add(t);
            database.SaveChanges();
            return View();
        }

        public async Task<IActionResult> DashBoard()
        {
            //token
            var myself = this.User;

            //IdentityUser objektum lekérés
            IdentityUser current =
                await usermanager.GetUserAsync(myself);

            var filtered = database.
                Todos.Where(t => t.UserId == current.Id);

            return View(filtered);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
