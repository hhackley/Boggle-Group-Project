using BoggleAPI;

namespace BoggleAPITest
{
    public class ScoreEngineTest
    {
        ScoreEngine engine;
        string wordLen1;
        string wordLen3;
        string wordLen4;
        string wordLen5;
        string wordLen7;
        string wordLen8;

        [SetUp]
        public void Setup()
        {
            engine = new ScoreEngine();

            wordLen1 = "I";
            wordLen3 = "New";
            wordLen4 = "Test";
            wordLen5 = "Water";
            wordLen7 = "Bottles";
            wordLen8 = "Tempting";
        }

        [Test]
        public void TestCalculateWordScore()
        {
            int score = engine.CalculateWordScore(wordLen1);
            Assert.That(score, Is.EqualTo(0));

            score = engine.CalculateWordScore(wordLen3);
            Assert.That(score, Is.EqualTo(1));

            score = engine.CalculateWordScore(wordLen4);
            Assert.That(score, Is.EqualTo(1));

            score = engine.CalculateWordScore(wordLen5);
            Assert.That(score, Is.EqualTo(2));

            score = engine.CalculateWordScore(wordLen7);
            Assert.That(score, Is.EqualTo(5));

            score = engine.CalculateWordScore(wordLen8);
            Assert.That(score, Is.EqualTo(11));

        }
    }
}