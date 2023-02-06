using BoggleAPI.Source.Manager;
using BoggleAPI.Source.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoggleAPI.Source.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerClient : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            var PlayerManager = new PlayerManager();
            return PlayerManager.GetPlayers();
        }

        [HttpPost]
        public void PostPlayers([FromBody] Player[] players)
        {
            var PlayerManager = new PlayerManager();
            PlayerManager.AddPlayers(players);
        }

        [HttpDelete]
        public void DeletePlayers()
        {
            var PlayerManager = new PlayerManager();
            PlayerManager.DeletePlayers();
        }
    }
}
