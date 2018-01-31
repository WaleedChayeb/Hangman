using System.Web.Mvc;

namespace HangmanAub.Controllers
{
    public class HomeController : Controller
    {
        static Hangman game;

        public ActionResult Index()
        {
            game = new Hangman();
            return View(game.StartGame());
        }
        [HttpPost]
        public ActionResult Index(char c)
        {
            Result r = game.Answer(c);
            return View(r);
        }
    }
}