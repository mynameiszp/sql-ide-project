using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQL.Data;
using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public class TableEntityRepository : ITableEntityRepository, IDisposable
    {
        private bool disposedValue;
        private SqlDataContext _context;

        public TableEntityRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }

        public void DeleteTable(TableEntity table)
        {
            _context.Tables.Remove(table);
        }

        public void DeleteAllColumns(TableEntity table)
        {
            if (GetTableByID(table.Id) != null)
            {
                foreach (ColumnEntity column in GetTableByID(table.Id).Columns)
                {
                    _context.Columns.Remove(column);
                }
                Save();
            }
        }
        public TableEntity GetTableByID(long tableID)
        {
            return _context.Tables.Find(tableID);
        }
        public TableEntity? GetTableByName(string tableName)
        {
            return _context.Tables.FirstOrDefault(s => s.Name == tableName);
        }

        public IEnumerable<TableEntity> GetTables()
        {
            return _context.Tables.ToList();
        }

        public void InsertTable(TableEntity table)
        {
            _context.Tables.Add(table);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTable(TableEntity table)
        {
            _context.Entry(table).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
