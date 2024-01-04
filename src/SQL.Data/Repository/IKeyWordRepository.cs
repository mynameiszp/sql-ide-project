using SQL.Data.Entities;

namespace SQL.Data.Repository
{
    public interface IKeyWordRepository: IDisposable
    {
        IEnumerable<KeyWord> GetKeyWords();
        KeyWord GetKeyWordByID(int keyWordID);
        KeyWord? GetKeyWordByName(string keyWordName);
        void InsertKeyWord(KeyWord keyWord);
        void DeleteKeyWord(KeyWord keyWord);
        void UpdateKeyWord(KeyWord keyWord);
        void Save();
    }
}