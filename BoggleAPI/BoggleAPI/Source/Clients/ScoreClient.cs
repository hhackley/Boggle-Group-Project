using BoggleAPI.Source.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BoggleAPI.Source.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreClient : ControllerBase
    {
        [HttpGet]
        public int GetScore(int playerId)
        {
            var scoreManager = new ScoreManager();

            return scoreManager.GetScore(playerId);
        }
    }
}
