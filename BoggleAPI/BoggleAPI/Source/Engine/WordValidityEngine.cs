

using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.IEngine;

namespace BoggleAPI
{
    public class WordValidityEngine : IWordValidityEngine
    {
        //int assignments for the board size for IsWordOnBoard method and LocateWord method
        static readonly int r = 4;
        static readonly int c = 4;
        public bool IsWordValid(string wordGuessed, int playerId)
        {
            var boardAccessor = new BoardAccessor();
            var WordAccessor = new WordAccessor();

            wordGuessed = wordGuessed.ToUpper();
            bool isWordInDictionary = WordAccessor.IsWordInDictionary(wordGuessed);
            if (IsWordCorrectLength(wordGuessed) && isWordInDictionary && IsWordOnBoard(boardAccessor.GetBoard(), wordGuessed, r, c))
            {
                WordAccessor.PostCorrectWord(wordGuessed, playerId);
                return true;
            } 
            else
            {
                return false;
            }
        }

        static bool LocateMatch(String[,] board, string wordGuessed, int x, int y, int row, int column, int letter)
        {

            if (wordGuessed.Length == letter)
            {
                return true;
            }

            //Checking for out of bounds
            if (x < 0 || y < 0 || x >= row || y >= column)
            {
                return false;
            }

            //taking the wordGuessed and checking if the first letter exists on the board. If true, then checking to see
            //if the next letter in wordGuessed exists in its surrounding letter and so forth, returning true if finding the entire word,
            //false if it does not find the next letters around it.
            if (board[x, y] == wordGuessed[letter].ToString())
            {
                string tmp = board[x, y];
                board[x, y] = "#";

                bool result = LocateMatch(board, wordGuessed, x - 1, y, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x + 1, y, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x, y - 1, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x, y + 1, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x - 1, y - 1, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x + 1, y + 1, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x + 1, y - 1, row, column, letter + 1) |
                              LocateMatch(board, wordGuessed, x - 1, y + 1, row, column, letter + 1);
                board[x, y] = tmp;
                return result;
            }
            else
                return false;
        }


        public bool IsWordOnBoard(String[,] board, string wordGuessed, int row, int column)
        {        
            //check if word is valid length
            IsWordCorrectLength(wordGuessed);
            //for loop to run through each column and row checking for letters

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //checking if the first letter from wordGuessed exists on the board
                    if (board[i, j] == wordGuessed[0].ToString())
                    {
                        //running LocateMatch method to locate and verify if the word exists on the board.
                        if (LocateMatch(board, wordGuessed, i, j, row, column, 0))
                        {
                            return true;
                        }
                    }
                }

            }

            return false;
        }
        public bool IsWordCorrectLength(string wordGuessed)
        {
            return wordGuessed.Length > 2 && wordGuessed.Length < 17;
        }
    }
}
