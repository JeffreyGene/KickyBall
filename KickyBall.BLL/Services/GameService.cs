using KickyBall.BLL.Interfaces;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public Game GetGame()
        {
            return _context.Games.FirstOrDefault();
        }

        public GoalAttempt CreateGoalAttempt(GoalAttempt goalAttempt)
        {
            _context.GoalAttempts.Add(goalAttempt);
            _context.SaveChanges();
            return goalAttempt;
        }
        public Round CreateRound(Round round)
        {
            _context.Rounds.Add(round);
            _context.SaveChanges();
            return round;
        }
        public Game CreateGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }
    }
}
