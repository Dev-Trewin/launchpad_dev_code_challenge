using System.Numerics;

namespace tic_tac_toe_api.Data.Entities
{
    public class Game
    {
        public Guid GameId { get; set; }
        public Guid PlayerOneId { get; set; }
        public Guid PlayerTwoId { get; set; }

   
    }
}
