using SQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL.Data.Repository
{
    public class DataRepository : IDataRepository, IDisposable
    {
        private bool disposedValue = false;
        private SqlDataContext _context;

        public DataRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }
        public void DeleteData(Datas data)
        {
            _context.Data.Remove(data);
            Save();
        }

        public Datas GetDataByID(int dataID)
        {
            return _context.Data.Find(dataID);
        }

        public IEnumerable<Datas> GetDatas()
        {
            return _context.Data.ToList();
        }

        public void InsertData(Datas data)
        {
            _context.Add(data);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateData(Datas data)
        {
            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
