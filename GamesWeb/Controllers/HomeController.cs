using GamesWeb.Data;
using GamesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GamesWeb.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace GamesWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("logged_user") == null)
            {
                HttpContext.Session.SetString("logged_user", Guid.Empty.ToString());
            }
            var user = _context.Users.Find(Guid.Parse(HttpContext.Session.GetString("logged_user")));
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            var user = _context.Users.FirstOrDefault(m => m.Name == model.Name && m.Password == model.Password);

            if (user == null)
            {
                return View(model);
            }

            HttpContext.Session.SetString("logged_user", user.Id.ToString());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(UserModel model, string repassword, IFormFile pfp )
        {
            model.PfpName = "";
            model.MembershipIds = "";
            model.GameIds = "";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (pfp != null && pfp.Length != 0)
            {
                string ext = Path.GetExtension(pfp.FileName), path = Path.GetFullPath("wwwroot") + "/img";
                string name = Guid.NewGuid().ToString() + ext;
                pfp.CopyTo(new FileStream(Path.Combine(path, name), FileMode.Create));
                model.PfpName = name;
            }

            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("logged_user", Guid.Empty.ToString());
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CreateMembership()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMembership(MembershipModel model, IFormFile logo)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (logo != null && logo.Length != 0)
            {
                string ext = Path.GetExtension(logo.FileName), path = Path.GetFullPath("wwwroot") + "/img";
                string name = Guid.NewGuid().ToString() + ext;
                logo.CopyTo(new FileStream(Path.Combine(path, name), FileMode.Create));
                model.LogoName = name;
            }

            _context.Memberships.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("AdminPanel", "Home");
        }

        public IActionResult AdminPanel()
        {
            ViewData["memberships"] = _context.Memberships.ToArray();
            ViewData["games"] = _context.Games.ToArray();
            ViewData["users"] = _context.Users.ToArray();

            var user = _context.Users.Find(Guid.Parse(HttpContext.Session.GetString("logged_user")));
            return View(user);
        }
        public IActionResult RemoveUser(Guid id)
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return RedirectToAction("AdminPanel", "Home");
        }
        public IActionResult RemoveMembership(Guid id)
        {
            var membership = _context.Memberships.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (membership != null)
            {
                _context.Memberships.Remove(membership);
            }
            return RedirectToAction("AdminPanel", "Home");
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
