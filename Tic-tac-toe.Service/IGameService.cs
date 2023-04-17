using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tic_tac_toe_api.Data.Entities;

namespace Tic_tac_toe.Service
{
    public interface IGameService
    {
        Task CreateAsync(Game newGame);
        Task<JsonResult> Retrivegame();
    }
}
