using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using snake_asp.game;
using snake_asp.Models.Api;
using System.Drawing;

namespace snake_asp.Controllers
{
    // [Route("api/[controller]")]
    //  [ApiController]
    public class ApiController : Controller
    {
        private Game _game;

        public ApiController(Game game)
        {
            _game = game;
        }

        public IActionResult GetStatus()
        {
            var dataModel = new GetStatusDataModel(_game);

            return PartialView("/Views/PageParts/SnakeStatus.cshtml", dataModel);


        }


        public IActionResult GetFiend()
        {

            var dataModel = new GetFieldDataModel(_game);

            return PartialView("/Views/PageParts/SnakeTable.cshtml", dataModel);

        }
        public GetStatusDataModel SnakeStatusDataModel()
        {
            return new GetStatusDataModel(_game);
        }

        public void GoUp()
        {
            _game.Snake.Speed = new Point(0, -1);
        }

        public void GoDown()
        {
            _game.Snake.Speed = new Point(0, +1);
        }

        public void GoLeft()
        {
            _game.Snake.Speed = new Point(-1, 0);
        }

        public void GoRigth()
        {
            _game.Snake.Speed = new Point(+1, 0);
        }

    }
}
