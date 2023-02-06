using BoggleAPI.Source.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BoggleAPI.Source.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardClient : ControllerBase
    {
        [HttpGet]
        public string GetBoard()
        {
            var BoardManager = new BoardManager();
            string[,] board = BoardManager.GetBoard();

            string boardAsString = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    boardAsString += board[i, j];
                }
            }

            return boardAsString;
        }
    }
}
