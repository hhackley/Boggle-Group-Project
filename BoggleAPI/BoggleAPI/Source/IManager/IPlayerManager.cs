using BoggleAPI.Source.Models;

namespace BoggleAPI.Source.IManager
{
    public interface IPlayerManager
    {
        public void AddPlayers(Player[] players);
        public void DeletePlayers();
        public Player[] GetPlayers();
    }
}
