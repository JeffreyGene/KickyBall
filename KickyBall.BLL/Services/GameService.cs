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
            //check null
            return (int)_context.Games
                .Include(g => g.Rounds)
                .ThenInclude(r => r.GoalAttempts)
                .FirstOrDefault(g => g.GameId == gameId).Rounds.Sum(r => r.GoalAttempts.Count(a => a.ScoredGoal));
        }

        public int GetPracticeGoals(int gameId)
        {
            //check null
            return (int)_context.Games
                .Include(g => g.Rounds)
                .ThenInclude(r => r.GoalAttempts)
                .FirstOrDefault(g => g.GameId == gameId).Rounds.Where(r => r.Practice).Sum(r => r.GoalAttempts.Count(a => a.ScoredGoal));
        }

        public int GetRoundGoals(int roundId)
        {
            //check null
            return (int)_context.Rounds
                .Include(r => r.GoalAttempts)
                .FirstOrDefault(r => r.RoundId == roundId).GoalAttempts.Count(a => a.ScoredGoal);
        }

        public List<int> GetEndPositionsForRound(int roundId)
        {
            //check null
            return _context.Rounds
                .Include(r => r.GoalAttempts)
                .ThenInclude(a => a.Moves)
                .FirstOrDefault(r => r.RoundId == roundId).GoalAttempts.Select(a => a.Moves.OrderByDescending(m => m.Ordinal).FirstOrDefault().FieldPositionId).ToList();
        }

        public int GetGoalAttemptNumberForRound(int roundId)
        {
            //check null
            Round round = _context.Rounds
                .Include(r => r.GoalAttempts)
                .FirstOrDefault(r => r.RoundId == roundId);

            if(round.GoalAttempts.Count == 0)
            {
                return 1;
            }
            return round.GoalAttempts.Max(a => a.Ordinal) + 1;
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
