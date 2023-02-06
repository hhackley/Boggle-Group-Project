using BoggleAPI;

namespace BoggleAPITest
{
    public class ShuffleEngineTest
    {
        ShuffleEngine engine;

        [SetUp]
        public void Setup()
        {
            engine = new ShuffleEngine();
        }

        [Test]
        public void TestGetBoard()
        {
            String[,] board = engine.GetBoard();

            Assert.NotNull(board);
            Assert.That(board.Length, Is.EqualTo(16));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.NotNull(board[i, j]);
                }
            }            
        }
    }
}