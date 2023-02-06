using BoggleAPI.Source.IAccessorRepository;
using MySql.Data.MySqlClient;


namespace BoggleAPI.Source.AccessorRepository
{
    public class WordAccessor : IWordAccessor
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void PostCorrectWord(string wordGuessed, int playerId)
        {
            //Parameterized query which helps protect against SQL Injection
            string query = $"INSERT INTO correctwords (Word, PlayerId) VALUES ('{wordGuessed}', {playerId});";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    //Prepare statement to help against SQL Injection
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public bool IsWordInDictionary(string word)
        {
            Boolean isWordPresent = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = $"SELECT DISTINCT word FROM dictionary WHERE (word) LIKE '{word}'";
                conn.Open();
                using(MySqlCommand command = new MySqlCommand(query,conn))
                {
                    if (command.ExecuteScalar() != null)
                    {
                        isWordPresent = true;
                    }
                }
                conn.Close();
            }

            return isWordPresent;
        }

        public string[] GetPlayerWords(int playerID)
        {
            string[] words = new string[1];

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = $"SELECT DISTINCT Word FROM correctwords WHERE (PlayerId) = {playerID}";
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader dataReader = command.ExecuteReader())
                    {
                        try
                        {
                            List<string> wordList = new List<string>();
                            while (dataReader.Read())
                            {
                                wordList.Add(dataReader.GetString("Word"));
                                Console.WriteLine(dataReader.GetString("Word"));
                            }
                            words = wordList.ToArray();
                        }
                        catch
                        {
                            words[0] = "";
                        }
                    }
                }
                conn.Close();
            }

            return words;
        }

        public void DeleteWords()
        {
            string query = $"DELETE FROM correctwords WHERE true;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
