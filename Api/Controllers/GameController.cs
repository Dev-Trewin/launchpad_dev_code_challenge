using Microsoft.AspNetCore.Mvc;
using Tic_tac_toe.Service;
using tic_tac_toe_api.Data.Entities;

namespace tic_tac_toe_api.Controllers
{
    public class GameController:Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
           
        }
        [HttpPost]
        public async Task<IActionResult> StartGame(int playerOneId, int playerTwoId)
        {
            var Newgame = new Game
            {
                PlayerOneId = playerOneId,
                PlayerTwoId = playerTwoId
            };

            await _gameService.CreateAsync(Newgame);

            return Ok(Newgame);
        }
    }
}
