using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tic_tac_toe.Service;
using tic_tac_toe_api.Data.Entities;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;

        }
        [HttpPost]
        [HttpPost("start")]
        public async Task<JsonResult> StartGame()
        {
        
            var Newgame = new Game
            {
                GameId = Guid.NewGuid(),
                PlayerOneId = Guid.NewGuid(),
                PlayerTwoId = Guid.NewGuid(),
            };

            await _gameService.CreateAsync(Newgame);

            return new JsonResult(Ok(Newgame));
        }
        [HttpGet("welcome")]
        public JsonResult Index()
        {
            return new JsonResult(Ok());
        }
    }
}
