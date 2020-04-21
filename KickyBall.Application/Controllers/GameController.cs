using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Services;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KickyBall.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<FieldPositionController> _logger;
        private readonly IGameService _service;

        public GameController(ILogger<FieldPositionController> logger, IGameService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Game GetGame()
        {
            return _service.GetGame();
        }

        [HttpPost]
        public GoalAttempt CreateGoalAttempt(GoalAttempt goalAttempt)
        {
            return _service.CreateGoalAttempt(goalAttempt);
        }

        [HttpPost]
        public Round CreateRound(Round round)
        {
            return _service.CreateRound(round);
        }

        [HttpPost]
        public Game CreateGame(Game game)
        {
            return _service.CreateGame(game);
        }
    }
}
