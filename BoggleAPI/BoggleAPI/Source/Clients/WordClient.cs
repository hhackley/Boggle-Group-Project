using BoggleAPI.Source.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BoggleAPI.Source.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordClient : ControllerBase
    {
        [HttpPost]
        public bool GuessWord(string wordGuessed, int playerId)
        {
            var WordManager = new WordManager();
            return WordManager.GuessWord(wordGuessed, playerId);
        }


        [HttpDelete]
        public void DeleteWords()
        {
            var WordManager = new WordManager();
            WordManager.DeleteWords();
        }
    }
}
