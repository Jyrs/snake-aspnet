using Microsoft.AspNetCore.Mvc;
using snake_asp.game;
using snake_asp.Models.Api;

namespace snake_asp.Controllers
{
    public class GAMEcontroller : Controller
    {
        private readonly Game _game;
        public GAMEcontroller(Game game)
        {
            _game = game;
        }


        public IActionResult Index()
        {
            //var dataModel = new GetFieldDataModel(_game);
            return View(_game);
        }

    }
}
