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
            await db.Games.AddAsync(game);
            await db.SaveChangesAsync();

        }
    }
}
