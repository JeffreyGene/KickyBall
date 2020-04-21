using KickyBall.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Interfaces
{
    public interface IGameService
    {
        Game GetGame();
        GoalAttempt CreateGoalAttempt(GoalAttempt goalAttempt);
        Round CreateRound(Round round);
        Game CreateGame(Game game);
    }
}
