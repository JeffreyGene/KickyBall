using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickyBall.BLL.Services
{
    public class GameService : IGameService
    {
        private KickyBallContext _context;
        public GameService(KickyBallContext context)
        {
            _context = context;
        }

        public Game GetCurrentGame(int userId)
        {
            Game game = _context.Games.Include(g => g.Rounds).FirstOrDefault(g => g.UserId == userId);
            if(game != null)
            {
                game.Rounds = game.Rounds.OrderBy(r => r.Ordinal).ToList();
            }
            return game;
        }

        public int GetGameGoals(int gameId)
        {
            return _context.Games.Where(g => g.GameId == gameId).Select(g => g.Rounds.Sum(r => GetRoundGoals(r.RoundId))).FirstOrDefault();
        }

        private int BoolToInt(bool scoredGoal)
        {
            if (scoredGoal)
            {
                return 1;
            }
            return 0;
        }

        public int GetRoundGoals(int roundId)
        {
           return _context.Rounds.Where(r => r.RoundId == roundId).Select(r => r.GoalAttempts.Sum(a => BoolToInt(a.ScoredGoal))).FirstOrDefault();
        }

        public GoalAttempt RecordGoalAttempt(RecordGoalAttemptRequest request)
        {
            _context.GoalAttempts.Add(request.GoalAttempt);
            Round round = _context.Rounds.FirstOrDefault(r => r.RoundId == request.GoalAttempt.RoundId);
            round.SecondsRemaining = request.SecondsRemaining;
            _context.SaveChanges();
            return request.GoalAttempt;
        }
        public Round CreateRound(Round round)
        {
            _context.Rounds.Add(round);
            _context.SaveChanges();
            return round;
        }

        public bool FinishRound(int roundId)
        {
            Round round = _context.Rounds.FirstOrDefault(r => r.RoundId == roundId);
            round.Finished = true;
            round.SecondsRemaining = 0;
            _context.SaveChanges();
            return true;
        }
        public Game CreateGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public bool FinishGame(int gameId)
        {
            Game game = _context.Games.FirstOrDefault(r => r.GameId == gameId);
            game.Finished = true;
            _context.SaveChanges();
            return true;
        }
    }
}
