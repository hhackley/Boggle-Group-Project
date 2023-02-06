
using BoggleAPI;

namespace BoggleAPITest.SourceTest.EngineTest
{
    internal class WordValidityEngineTest
    {
        BoggleAPI.ShuffleEngine engine;


        [SetUp]
        public void setup()
        {
            engine = new BoggleAPI.ShuffleEngine();

        }

        [Test]
        public void isWordCorrect1()
        {
            int row = 4;
            int column = 4;
            string word = "TEST";
            var WordEngine = new WordValidityEngine();
            string[,] board =
            {
                { "T", "E", "S", "T" },
                { "E", "D", "A", "B" },
                { "S", "W", "Z", "R" },
                { "T", "J", "Y", "P" }
            };
            bool actual = WordEngine.IsWordOnBoard(board, word, row, column);
            bool expected = true;
            Assert.That(actual, Is.EqualTo(expected));

        }
        [Test]
        public void isWordCorrect2()
        {
            int row = 4;
            int column = 4;
            string word = "BAD";
            var WordEngine = new WordValidityEngine();
            string[,] board =
            {
                { "T", "E", "S", "T" },
                { "E", "D", "A", "B" },
                { "S", "W", "Z", "R" },
                { "T", "J", "Y", "P" }
            };
            bool actual = WordEngine.IsWordOnBoard(board, word, row, column);
            bool expected = true;
            Assert.That(actual, Is.EqualTo(expected));

        }
        [Test]
        public void isWordCorrect3()
        {
            int row = 4;
            int column = 4;
            string word = "BADGER";
            var WordEngine = new WordValidityEngine();
            string[,] board =
            {
                { "T", "E", "S", "T" },
                { "E", "D", "A", "B" },
                { "S", "W", "Z", "R" },
                { "T", "J", "Y", "P" }
            };
            bool actual = WordEngine.IsWordOnBoard(board, word, row, column);
            bool expected = false;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void isWordCorrect4()
        {
            int row = 4;
            int column = 4;
            string word = "BEAUTIFUL";
            var WordEngine = new WordValidityEngine();
            string[,] board =
            {
                { "B", "T", "I", "T" },
                { "U", "E", "F", "B" },
                { "A", "W", "Z", "U" },
                { "T", "J", "L", "P" }
            };
            bool actual = WordEngine.IsWordOnBoard(board, word, row, column);
            bool expected = true;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void isWordCorrect5()
        {
            int row = 4;
            int column = 4;
            string word = "TEST";
            var WordEngine = new WordValidityEngine();
            string[,] board =
            {
                { "T", "A", "S", "Q" },
                { "E", "E", "A", "T" },
                { "S", "W", "Z", "R" },
                { "T", "J", "Y", "P" }
            };
            bool actual = WordEngine.IsWordOnBoard(board, word, row, column);
            bool expected = true;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void isWordCorrect6()
        {
            int row = 4;
            int column = 4;
            string word = "TEST";
            var WordEngine = new WordValidityEngine();
            string[,] board =
            {
                { "T", "A", "S", "Q" },
                { "E", "X", "A", "T" },
                { "X", "W", "Z", "R" },
                { "Q", "J", "Y", "P" }
            };
            bool actual = WordEngine.IsWordOnBoard(board, word, row, column);
            bool expected = false;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void IsWordCorrectLength1()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = true;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("apple");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength2()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = false;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("a");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength3()
        {
            Assert.Pass();
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = true;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("averylongstringg");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength4()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = false;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("averylongstringggggg");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength5()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = true;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("university");

            // Assert
            Assert.That(actual, Is.EqualTo(actual));
        }
    }
}

