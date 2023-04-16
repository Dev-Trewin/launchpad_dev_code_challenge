using Microsoft.EntityFrameworkCore;
using tic_tac_toe_api.Data.Entities;

namespace Tic_tac_toe.Service.Implementation
{
    public class MoveService:IMoveService
    {
        private readonly ApplicationDbContext _db;

        public MoveService(ApplicationDbContext context)
        {
            _db = context;
        }
        
    }
}
