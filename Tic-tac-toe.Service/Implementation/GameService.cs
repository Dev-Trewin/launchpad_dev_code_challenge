using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tic_tac_toe_api.Data.Entities;

namespace Tic_tac_toe.Service.Implementation
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _db;
        private readonly IPlayerService _playerService;
        public GameService(ApplicationDbContext context, IPlayerService playerService)
        {
            _db = context;
            _playerService = playerService;
        }

        public async Task CreateAsync(Game game)
        {
            await _playerService.CreateAsync(game);
            await _db.Games.AddAsync(game);
            await _db.SaveChangesAsync();

        }

        public async Task<JsonResult> Retrivegame()
        {
            try
            {
              var runningGames = _db.Games
             .Include(g => g.Moves)
             .ThenInclude(m => m.Player)
             .Select(g => new
             {
                 GameId = g.GameId,
                 NumMoves = g.Moves.Count(),
                 PlayerNames = g.Moves.Select(m => m.Player.Name).ToList()
             })
             .ToList();

                return new JsonResult(runningGames);
            }
            catch (Exception ex)
            {
                // log the exception here
                return new JsonResult("An error occurred while retrieving running games.");
            }
        }
    }

    }
