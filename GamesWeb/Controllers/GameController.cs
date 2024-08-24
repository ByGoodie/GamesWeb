using GamesWeb.Data;
using GamesWeb.Models.DbModel;
using Microsoft.AspNetCore.Mvc;

namespace GamesWeb.Controllers
{
    public class GameController : Controller
    {
        LibraryContext _context;

        GameController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index(Guid game, Guid user)
        {
            var game_obj = _context.Games.Find(game);

            string[] memberships = game_obj.MembershipIds.Split('/');

            MembershipModel[] membs = new MembershipModel[memberships.Length];
            
            for (int i = 0; i < memberships.Length; i++)
            {
                Guid id = Guid.Parse(memberships[i]);
                membs[i] = _context.Memberships.Find(id);
            }

            ViewData["memberships"] = membs;
            ViewData["game"] = game_obj;
            ViewData["user"] = _context.Games.FirstOrDefault(m => m.Id == user);
            return View();
        }
    }
}
