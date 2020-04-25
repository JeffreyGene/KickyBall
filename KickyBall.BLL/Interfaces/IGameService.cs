using KickyBall.BLL.Requests;
using KickyBall.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Interfaces
{
    public interface IGameService
    {
        Game GetCurrentGame(int userId);
        GoalAttempt RecordGoalAttempt(RecordGoalAttemptRequest goalAttempt);
        Round CreateRound(Round round);
        Game CreateGame(Game game);
        bool FinishRound(int roundId);
        bool FinishGame(int gameId);
        int GetGameGoals(int gameId);
        int GetRoundGoals(int roundId);
        List<int> GetEndPositionsForRound(int roundId);
        int GetGoalAttemptNumberForRound(int roundId);
        int GetPracticeGoals(int gameId);
    }
}
