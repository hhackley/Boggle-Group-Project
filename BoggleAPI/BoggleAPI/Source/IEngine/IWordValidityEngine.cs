namespace BoggleAPI.Source.IEngine
{
    public interface IWordValidityEngine
    {
        public bool IsWordValid(string wordGuessed, int playerId);
        public bool IsWordOnBoard(string[,] board, string wordGuessed, int row, int column);
        public bool IsWordCorrectLength(string wordGuessed);
    }
}
