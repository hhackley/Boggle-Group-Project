using BoggleAPI.Source.AccessorRepository;

namespace BoggleAPI
{
    public class ShuffleEngine : IShuffleEngine
    {
        String[] die1 = new String[] { "R", "I", "F", "O", "B", "X" };
        String[] die2 = new String[] { "I", "F", "E", "H", "E", "Y" };
        String[] die3 = new String[] { "D", "E", "N", "O", "W", "S" };
        String[] die4 = new String[] { "U", "T", "O", "K", "N", "D" };
        String[] die5 = new String[] { "H", "M", "S", "R", "A", "O" };
        String[] die6 = new String[] { "L", "U", "P", "E", "T", "S" };
        String[] die7 = new String[] { "A", "C", "I", "T", "O", "A" };
        String[] die8 = new String[] { "Y", "L", "G", "K", "U", "E" };
        String[] die9 = new String[] { "QU", "B", "M", "J", "O", "A" };
        String[] die10 = new String[] { "E", "H", "I", "S", "P", "N" };
        String[] die11 = new String[] { "V", "E", "T", "I", "G", "N" };
        String[] die12 = new String[] { "B", "A", "L", "I", "Y", "T" };
        String[] die13 = new String[] { "E", "Z", "A", "V", "N", "D" };
        String[] die14 = new String[] { "R", "A", "L", "E", "S", "C" };
        String[] die15 = new String[] { "U", "W", "I", "L", "R", "G" };
        String[] die16 = new String[] { "P", "A", "C", "E", "M", "D" };
        
        public String[,] GetBoard()
        {
            List <String[]> dice = new List<String[]>();
            dice.Add(die1);
            dice.Add(die2);
            dice.Add(die3);
            dice.Add(die4);
            dice.Add(die5);
            dice.Add(die6);
            dice.Add(die7);
            dice.Add(die8);
            dice.Add(die9);
            dice.Add(die10);
            dice.Add(die11);
            dice.Add(die12);
            dice.Add(die13);
            dice.Add(die14);
            dice.Add(die15);
            dice.Add(die16);

            Random rnd = new Random();

            String[,] board = new String[4, 4];

            for (int i=0; i<4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    int rndNum = rnd.Next(dice.Count);
                    board[i, j] = dice[rnd.Next(rndNum)][rnd.Next(6)];
                    dice.RemoveAt(rndNum);
                }
            }

            return board;
        }

        public String[,] SetNewBoard()
        {
            String[,] newBoard = GetBoard();
            BoardAccessor boardAccessor= new BoardAccessor();
            boardAccessor.SetBoard(newBoard);

            return newBoard;
        }
    }
}