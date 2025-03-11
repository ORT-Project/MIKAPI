// IScoreService.cs
using MekiApi.Models;
using System.Collections.Generic;
namespace MekiApi.Services
{
    public interface IScoreService
    {
        Score? GetScoreById(int id);
        void AddScore(Score score);
        List<Score> GetScores();
    }
}