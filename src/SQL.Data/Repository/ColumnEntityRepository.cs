using SQL.Data;
using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public class ColumnEntityRepository : IColumnEntityRepository, IDisposable
    {
        private bool disposedValue;
        private SqlDataContext _context;

        public ColumnEntityRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }

        public void DeleteColumn(ColumnEntity column)
        {
            _context.Columns.Remove(column);
        }

        public ColumnEntity GetColumnByID(int columnID)
        {
            return _context.Columns.Find(columnID);
        }
        public ColumnEntity? GetColumnByName(string columnName)
        {
            return _context.Columns.FirstOrDefault(s => s.Name == columnName);
        }

        public IEnumerable<ColumnEntity> GetColumns()
        {
            return _context.Columns.ToList();
        }

        public void InsertColumn(ColumnEntity column)
        {
            _context.Columns.Add(column);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateColumn(ColumnEntity column)
        {
            _context.Entry(column).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
