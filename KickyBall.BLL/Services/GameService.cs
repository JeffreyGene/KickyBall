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
            Game game = _context.Games.Include(g => g.Rounds).ThenInclude(r => r.GoalAttempts).FirstOrDefault(g => g.UserId == userId);
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

        public List<int> GetRouteIdsForGame(int gameId, int take)
        {
            //check null
            return _context.Games
                .Include(g => g.Rounds)
                .ThenInclude(r => r.GoalAttempts)
                .FirstOrDefault(g => g.GameId == gameId)
                .Rounds
                .OrderByDescending(r => r.Ordinal)
                .SelectMany(r => r.GoalAttempts.OrderByDescending(a => a.Ordinal).Select(a => a.RouteId))
                .Take(take)
                .ToList();
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
            Round round = _context.Rounds.FirstOrDefault(r => r.RoundId == request.GoalAttempt.RoundId);
            round.SecondsRemaining = request.SecondsRemaining;
            RfCountToRouteAndGame currentRfCountToRouteAndGame = _context.RfToRouteAndGameList.FirstOrDefault(rf => rf.RouteId == request.GoalAttempt.RouteId && rf.GameId == round.GameId);
            currentRfCountToRouteAndGame.Value += 1;

            if (!round.Practice)
            {
                List<RfCountToRouteAndGame> otherRfCountToRouteAndGameList = _context.RfToRouteAndGameList.Where(rf => rf.GameId == round.GameId && rf.RouteId != request.GoalAttempt.RouteId).ToList();
                double sum = otherRfCountToRouteAndGameList.Sum(rf => rf.Value) + currentRfCountToRouteAndGame.Value;

                double newRf = currentRfCountToRouteAndGame.Value / sum;
                if(newRf <= 0.0825)
                {
                    //Score a goal! 
                    request.GoalAttempt.ScoredGoal = true;
                    currentRfCountToRouteAndGame.Value *= 0.95;
                    otherRfCountToRouteAndGameList.ForEach(rf => rf.Value *= 0.95);
                }
                else
                {
                    //Did not score a goal
                    request.GoalAttempt.ScoredGoal = false;
                }
            }
            else
            {
                request.GoalAttempt.ScoredGoal = new Random().Next(100) < 50;
            }

            _context.GoalAttempts.Add(request.GoalAttempt);
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
            game.StartTime = DateTime.Now;
            game.RfCountToRouteAndGameList = _context.Routes.Select(r => new RfCountToRouteAndGame
            {
                RouteId = r.RouteId,
                Value = 0
            }).ToList();
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public bool FinishGame(int gameId)
        {
            Game game = _context.Games.FirstOrDefault(r => r.GameId == gameId);
            game.Finished = true;
            game.EndTime = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
    }
}
