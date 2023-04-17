using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using tic_tac_toe_api.Data.Entities;
using System.Linq;
namespace Tic_tac_toe.Service.Implementation
{
    public class MoveService:IMoveService
    {
        private readonly ApplicationDbContext _db;

        public MoveService(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<bool> CreateAsync(Move move)
        {
            try
            {
                var game = _db.Games
                    .Include(g => g.Moves)
                    .FirstOrDefault(g => g.GameId == move.GameId);

                await _db.Moves.AddAsync(move);
                await _db.SaveChangesAsync();

                bool win = CheckForWin(game, move.Player.PlayerId, move.Row, move.Column);
                return win;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred while creating the move: {ex.Message}");
                return false;
            }
        }


        private bool CheckForWin(Game game, Guid playerId, int row, int column)
        {
            try
            {
                Guid[,] board = new Guid[3, 3];
                foreach (var move in game.Moves)
                {
                    if (move.Row >= 0 && move.Row < board.GetLength(0) && move.Column >= 0 && move.Column < board.GetLength(1))
                    {
                        board[move.Row, move.Column] = move.Player.PlayerId;
                    }
                }
                board[row, column] = playerId;

                // Check rows
                for (int i = 0; i < 3; i++)
                {
                    if ((board[i, 0] == playerId && board[i, 1] == playerId && board[i, 2] == playerId) ||
                        (board[0, i] == playerId && board[1, i] == playerId && board[2, i] == playerId))
                    {
                        return true;
                    }
                }

                // Check diagonals
                if ((board[0, 0] == playerId && board[1, 1] == playerId && board[2, 2] == playerId) ||
                    (board[0, 2] == playerId && board[1, 1] == playerId && board[2, 0] == playerId))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CheckForWin: {ex.Message}");
                throw;
            }
        }


    }
}
