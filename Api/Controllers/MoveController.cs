using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe.Service;
using Tic_tac_toe.Service.Implementation;
using tic_tac_toe_api.Data.Entities;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly IMoveService _moveService;
        private readonly ApplicationDbContext _db;
        public MoveController(IMoveService moveService, ApplicationDbContext context)
        {
            _moveService = moveService;
            _db = context;
        }

       
        [HttpPost("createmove")]
        public async Task<bool>CreateMove(Guid playerId,Guid gameId,int row,int col)
        {
          Move NewMove = null;
           var player= _db.Players.Where(m => m.PlayerId == playerId ).FirstOrDefault();
            if (player != null)
            {
                 NewMove = new Move
                {
                    MoveId = Guid.NewGuid(),
                    GameId = gameId,
                    Player = player,
                    Column = col,
                    Row = row,

                };
            }
           bool res = await _moveService.CreateAsync(NewMove);

            return (res);
               
        }
    }
}
