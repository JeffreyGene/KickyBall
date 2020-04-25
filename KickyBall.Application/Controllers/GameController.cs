using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
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
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _service;

        public GameController(ILogger<GameController> logger, IGameService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Game GetCurrentGame(int userId)
        {
            return _service.GetCurrentGame(userId);
        }

        [HttpGet]
        public int GetGameGoals(int gameId)
        {
            return _service.GetGameGoals(gameId);
        }

        [HttpGet]
        public int GetPracticeGoals(int gameId)
        {
            return _service.GetPracticeGoals(gameId);
        }

        [HttpGet]
        public int GetRoundGoals(int roundId)
        {
            return _service.GetRoundGoals(roundId);
        }

        [HttpGet]
        public List<int> GetEndPositionsForRound(int roundId)
        {
            return _service.GetEndPositionsForRound(roundId);
        }

        [HttpGet]
        public int GetGoalAttemptNumberForRound(int roundId)
        {
            return _service.GetGoalAttemptNumberForRound(roundId);
        }

        [HttpPost]
        public GoalAttempt RecordGoalAttempt(RecordGoalAttemptRequest request)
        {
            return _service.RecordGoalAttempt(request);
        }

        [HttpPost]
        public Round CreateRound(Round round)
        {
            return _service.CreateRound(round);
        }

        [HttpPost]
        public bool FinishRound([FromBody]int roundId)
        {
            return _service.FinishRound(roundId);
        }

        [HttpPost]
        public Game CreateGame(Game game)
        {
            return _service.CreateGame(game);
        }

        [HttpPost]
        public bool FinishGame([FromBody]int gameId)
        {
            return _service.FinishGame(gameId);
        }
    }
}
