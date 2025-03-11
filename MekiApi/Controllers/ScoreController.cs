using Microsoft.AspNetCore.Mvc;
using MekiApi.Models;
using MekiApi.Services;
using System.Collections.Generic;

namespace MekiApi.Controllers
{
    [ApiController]
    [Route("api/scores")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        // GET: api/scores
        [HttpGet]
        public ActionResult<List<Score>> GetScores()
        {
            var scores = _scoreService.GetScores();
            return Ok(scores);
        }

        // GET: api/scores/{id}
        [HttpGet("{id}")]
        public ActionResult<Score> GetScoreById(int id)
        {
            var score = _scoreService.GetScoreById(id);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        // POST: api/scores
        [HttpPost]
        public ActionResult<Score> AddScore([FromBody] Score score)
        {
            _scoreService.AddScore(score);
            return CreatedAtAction(nameof(GetScoreById), new { id = score.Id }, score);
        }
    }
}