using SQL.Data;
using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public class SchemeEntityRepository : ISchemeEntityRepository, IDisposable
    {
        private bool disposedValue = false;
        private SqlDataContext _context;

        public SchemeEntityRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }

        public void DeleteScheme(SchemeEntity scheme)
        {
            _context.Schemes.Remove(scheme);
        }
        public void DeleteAllTables(SchemeEntity scheme)
        {
            if (GetSchemeByID(scheme.Id) != null)
            {
                foreach (TableEntity table in GetSchemeByID(scheme.Id).Tables)
                {
                    _context.Tables.Remove(table);
                }
                Save();
            }
        }

        public IEnumerable<SchemeEntity> GetSchemes()
        {
            return _context.Schemes.ToList();
        }

        public SchemeEntity? GetSchemeByID(long schemeID)
        {
            return _context.Schemes.Find(schemeID);
        }

        public SchemeEntity? GetSchemeByName(string schemeName)
        {
            return _context.Schemes.FirstOrDefault(s => s.Name == schemeName);
        }

        public void InsertScheme(SchemeEntity scheme)
        {
            _context.Schemes.Add(scheme);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateScheme(SchemeEntity scheme)
        {
            _context.Entry(scheme).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
