using tic_tac_toe_api.Data.Entities;

namespace Tic_tac_toe.Service.Implementation
{
   

    public class PlayerService:IPlayer
    {
        private readonly ApplicationDbContext db;

        public PlayerService(ApplicationDbContext context)
        {
            db = context;
        }
    }
}
