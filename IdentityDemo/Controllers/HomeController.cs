using IdentityDemo.Data;
using IdentityDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IdentityDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Member> userManager;
        private readonly ApplicationDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<Member> userManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.db = db;
            this.roleManager = roleManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //var res = db.Users.Where(m => m.IsPro).ToList();

            //foreach (var m in res)
            //{
            //    var r =  await userManager.AddToRoleAsync(m, "Admin");
            //}

            var user = await userManager.GetUserAsync(User);
            if (user is not null)
            {
                var r = await userManager.AddToRoleAsync(user, "Admin");

            }

            // var userId = userManager.GetUserId(User);

            var rr = await roleManager.CreateAsync(new IdentityRole { Name = "Member" });

            if (User.Identity.IsAuthenticated)
            {

            }

            return View();
        }


        public async Task<IActionResult> Privacy()
        {

            var user = await userManager.GetUserAsync(User);
            if (User.IsInRole("Admin"))
            {
                var x = 5;

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}