using BoggleAPI.Source.IAccessorRepository;
using MySqlConnector;

namespace BoggleAPI.Source.AccessorRepository
{
    public class BoardAccessor : IBoardAccessor
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public string[,] GetBoard()
        {
            string[,] board = new string[4, 4];

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //Parameteried query which helps against SQL Injection
                string query = $"SELECT * FROM board";
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    //Using prepare statement to further protect against SQL Injection
                    command.Prepare();

                    String boardAsString = command.ExecuteScalar().ToString();

                    for (int i = 3; i >= 0; i--)
                    {
                        for (int j = 3; j >= 0; j--)
                        {
                            String currentLetter = boardAsString.Substring(boardAsString.Length - 1, 1);

                            if (currentLetter == "Q")
                            {
                                board[i, j] = currentLetter + "U";
                            }
                            else
                            {
                                board[i, j] = currentLetter;
                            }
                            
                            boardAsString = boardAsString.Substring(0, boardAsString.Length - 1);
                        }
                    }
                }
                conn.Close();
            }
            
            return board;
        }

        public void SetBoard(string[,] board)
        {
            // Delete pre-existing board
            string deleteQuery = $"DELETE FROM board WHERE true;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(deleteQuery, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

            // Add new board
            string boardAsString = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i,j].ToUpper() == "QU")
                    {
                        boardAsString += "Q";
                    }
                    else
                    {
                        boardAsString += board[i, j];
                    }
                }
            }
            string addQuery = $"INSERT INTO board (IDboard) VALUES ('{boardAsString}');";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(addQuery, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
    }
}
