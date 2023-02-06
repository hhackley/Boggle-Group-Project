

using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.IEngine;

namespace BoggleAPI
{
    public class ScoreEngine : IScoreEngine
    {

        public int GetTotalScore(int playerId)
        {
            int score = 0;
            WordAccessor wordAccessor = new WordAccessor();
            string[] playerWords = wordAccessor.GetPlayerWords(playerId);

            foreach (string word in playerWords)
            {
                score += CalculateWordScore(word);
            }

            return score;
        }

        public int CalculateWordScore(string word)
        {
            int score;

            if (word.Length == 3 || word.Length == 4) 
            {
                score = 1;
            }
            else if (word.Length == 5)
            {
                score = 2;
            }
            else if (word.Length == 6)
            {
                score = 3;
            }
            else if (word.Length == 7)
            {
                score = 5;
            }
            else if (word.Length >= 8)
            {
                score = 11;
            }
            else
            {
                return 0;
            }

            return score;
        }
    }
}
