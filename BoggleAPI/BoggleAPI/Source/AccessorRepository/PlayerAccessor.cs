using BoggleAPI.Source.IAccessorRepository;
using BoggleAPI.Source.Models;
using MySql.Data.MySqlClient;

namespace BoggleAPI.Source.AccessorRepository
{
    public class PlayerAccessor : IPlayerAccessor
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void AddPlayers(Player[] players)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                foreach (Player player in players)
                {
                    string values = $"({player.Id}, '{player.Username}', {player.Score})";
                    //Parameterized sql query to help against SQL Injection
                    string query = $"INSERT INTO players (Id, Username, Score) VALUES {values};";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        //Prepare statement to further help protect against SQL Injection
                        command.Prepare();

                        command.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
        }

        public void DeletePlayers()
        {
            string query = $"DELETE FROM players WHERE true;";
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

        public Player[] GetPlayers()
        {
            List<Player> playersList;
            string query = $"SELECT * FROM players;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    playersList = new List<Player>();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Player player = new Player();
                            player.Id = (int)reader["Id"];
                            player.Username = (string)reader["Username"];
                            player.Score = (int)reader["Score"];
                            playersList.Add(player);
                        }

                        conn.Close();
                    }
                }
            }
            
            return playersList.ToArray();
        }
    }
}
