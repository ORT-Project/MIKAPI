// ScoreService.cs
using MekiApi.Data;
using MekiApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MekiApi.Services
{
    public class ScoreService : IScoreService
    {
        private readonly AppDbContext _context;

        public ScoreService(AppDbContext context)
        {
            _context = context;
        }

        public Score? GetScoreById(int id)
        {
            var score = _context.Scores.Find(id);
            return score ?? throw new InvalidOperationException("Score not found.");
        }

        public void AddScore(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }

        public List<Score> GetScores()
        {
            return _context.Scores.ToList();
        }
    }
}