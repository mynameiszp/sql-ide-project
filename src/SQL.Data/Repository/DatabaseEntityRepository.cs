using SQL.Data;
using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public class DatabaseEntityRepository : IDatabaseEntityRepository, IDisposable
    {
        private bool disposedValue = false;
        private SqlDataContext _context;
        public DatabaseEntityRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }

        public void DeleteDatabase(DatabaseEntity database)
        {
            _context.Databases.Remove(database);
            Save();
        }
        public void DeleteAllSchemes(DatabaseEntity database)
        {
            if (GetDatabaseByID(database.Id) != null)
            {
                foreach (SchemeEntity scheme in GetDatabaseByID(database.Id).Schemes)
                {
                    _context.Schemes.Remove(scheme);
                }
                Save();
            }
        }

        public DatabaseEntity GetDatabaseByID(long databaseID)
        {
            return _context.Databases.Find(databaseID);
        }

        public IEnumerable<DatabaseEntity> GetDatabases()
        {
            return _context.Databases.ToList();
        }
        public DatabaseEntity? GetDatabaseByName(string databaseName)
        {
            return _context.Databases.FirstOrDefault(s => s.Name == databaseName);
        }

        public void InsertDatabase(DatabaseEntity database)
        {
            _context.Databases.Add(database);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDatabase(DatabaseEntity database)
        {
            _context.Entry(database).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
