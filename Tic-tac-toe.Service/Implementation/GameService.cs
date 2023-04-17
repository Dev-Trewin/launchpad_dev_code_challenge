using System.Numerics;
using tic_tac_toe_api.Data.Entities;

namespace Tic_tac_toe.Service.Implementation
{
    public class GameService:IGameService
    {
        private readonly ApplicationDbContext db;

        public GameService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task CreateAsync(Game game)
        {
            List<Player> players = new List<Player>()
            {
                new Player { PlayerId = game.PlayerOneId },
                new Player {  PlayerId = game.PlayerTwoId},
             
            };

            foreach (Player player in players)
            {
                await db.Players.AddAsync(player);
            }

            await db.SaveChangesAsync();
            await db.Games.AddAsync(game);
            await db.SaveChangesAsync();

        }
    }
}
