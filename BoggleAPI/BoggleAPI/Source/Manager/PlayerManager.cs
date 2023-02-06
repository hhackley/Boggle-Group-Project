using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.IManager;
using BoggleAPI.Source.Models;

namespace BoggleAPI.Source.Manager
{
    public class PlayerManager : IPlayerManager
    {
        public void AddPlayers(Player[] players)
        {
            var PlayerAccessor = new PlayerAccessor();
            PlayerAccessor.AddPlayers(players);
        }

        public void DeletePlayers()
        {
            var PlayerAccessor = new PlayerAccessor();
            PlayerAccessor.DeletePlayers();
        }

        public Player[] GetPlayers()
        {
            var PlayerAccessor = new PlayerAccessor();
            return PlayerAccessor.GetPlayers();
        }
    }
}
