using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public interface IColumnEntityRepository : IDisposable
    {
        IEnumerable<ColumnEntity> GetColumns();
        ColumnEntity GetColumnByID(int columnID);
        ColumnEntity? GetColumnByName(string columnName);
        void InsertColumn(ColumnEntity column);
        void DeleteColumn(ColumnEntity column);
        void UpdateColumn(ColumnEntity column);
        void Save();
    }
}
