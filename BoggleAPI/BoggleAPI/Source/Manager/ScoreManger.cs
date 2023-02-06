using BoggleAPI.Source.IManager;

namespace BoggleAPI.Source.Manager
{
    public class ScoreManager : IScoreManager
    {
        public int GetScore(int playerId)
        {
            var scoreEngine = new ScoreEngine();
            return scoreEngine.GetTotalScore(playerId);
        }
    }
}
