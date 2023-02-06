using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.IManager;

namespace BoggleAPI.Source.Manager
{
    public class BoardManager : IBoardManager
    {
        public string[,] GetBoard()
        {
            ShuffleEngine shuffleEngine = new ShuffleEngine();
            String[,] board = shuffleEngine.SetNewBoard();

            return board;
        }
    }
}
