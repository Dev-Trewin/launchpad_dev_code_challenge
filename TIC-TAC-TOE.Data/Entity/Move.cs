namespace tic_tac_toe_api.Data.Entities
{
    public class Move
    {
        public Guid MoveId { get; set; }
        public Guid GameId { get; set; }
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

    }
}
