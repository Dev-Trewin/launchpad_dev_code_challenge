using tic_tac_toe_api.Data.Entities;

namespace Tic_tac_toe.Service.Implementation
{
    public class MoveService:IMoveService
    {
        private readonly ApplicationDbContext db;

        public MoveService(ApplicationDbContext context)
        {
            db = context;
        }
    }
}
