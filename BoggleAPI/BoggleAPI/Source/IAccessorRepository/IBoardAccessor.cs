namespace BoggleAPI.Source.IAccessorRepository
{
    public interface IBoardAccessor
    {
        public void SetBoard(String[,] board);
        public String[,] GetBoard();
    }
}
