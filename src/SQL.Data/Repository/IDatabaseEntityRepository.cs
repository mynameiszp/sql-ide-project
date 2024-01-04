using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public interface IDatabaseEntityRepository : IDisposable
    {
        IEnumerable<DatabaseEntity> GetDatabases();
        DatabaseEntity GetDatabaseByID(long databaseID);
        DatabaseEntity? GetDatabaseByName(string databaseName);
        void InsertDatabase(DatabaseEntity database);
        void DeleteAllSchemes(DatabaseEntity database);
        void DeleteDatabase(DatabaseEntity database);
        void UpdateDatabase(DatabaseEntity database);
        void Save();
    }
}
