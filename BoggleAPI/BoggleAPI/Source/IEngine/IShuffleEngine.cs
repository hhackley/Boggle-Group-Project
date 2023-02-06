namespace BoggleAPI
{
    interface IShuffleEngine
    {
        public String[,] GetBoard();
        public String[,] SetNewBoard();
    }
}