namespace BoggleAPI.Source.IAccessorRepository
{
    public interface IWordAccessor
    {
        public void PostCorrectWord(string wordGuessed, int playerId);
        public bool IsWordInDictionary(string word);

        public void DeleteWords();
    }
}
