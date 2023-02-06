using BoggleAPI.Source.Models;

namespace BoggleAPI.Source.IAccessorRepository
{
    public interface IPlayerAccessor
    {
        public void AddPlayers(Player[] players);
        public void DeletePlayers();
        public Player[] GetPlayers();
    }
}
