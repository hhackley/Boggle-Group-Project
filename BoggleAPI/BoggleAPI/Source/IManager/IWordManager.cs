namespace BoggleAPI.Source.IManager
{
    public interface IWordManager
    {
        public bool GuessWord(string wordGuessed, int playerId);

        public void DeleteWords();
    }
}
