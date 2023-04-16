namespace tic_tac_toe_api.Data.Entities
{
    public class Move
    {
        public int MoveId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

    }
}
