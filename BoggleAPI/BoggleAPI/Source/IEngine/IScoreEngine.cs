namespace BoggleAPI.Source.IEngine
{
    public interface IScoreEngine
    {
        public int GetTotalScore(int playerId);
        public int CalculateWordScore(string word);
    }
}
