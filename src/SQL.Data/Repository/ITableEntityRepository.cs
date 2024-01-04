using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public interface ITableEntityRepository : IDisposable
    {
        IEnumerable<TableEntity> GetTables();
        TableEntity GetTableByID(long tableID);
        TableEntity? GetTableByName(string tableName);
        void InsertTable(TableEntity table);
        void DeleteAllColumns(TableEntity table);
        void DeleteTable(TableEntity table);
        void UpdateTable(TableEntity table);
        void Save();
    }
}
