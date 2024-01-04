using Microsoft.EntityFrameworkCore;
using SQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL.Data.Repository
{
    public class KeyWordRepository : IKeyWordRepository, IDisposable
    {
        private bool disposedValue = false;
        private SqlDataContext _context;
        public KeyWordRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }
        public void DeleteKeyWord(KeyWord keyWord)
        {
            _context.KeyWords.Remove(keyWord);
            Save();
        }

        public KeyWord GetKeyWordByID(int keyWordID)
        {
            return _context.KeyWords.Find(keyWordID);
        }

        public KeyWord? GetKeyWordByName(string keyWordName)
        {
            return _context.KeyWords.FirstOrDefault(s => s.Name == keyWordName);
        }

        public IEnumerable<KeyWord> GetKeyWords()
        {
            return _context.KeyWords.ToList();
        }

        public void InsertKeyWord(KeyWord keyWord)
        {
            _context.KeyWords.Add(keyWord);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateKeyWord(KeyWord keyWord)
        {
            _context.Entry(keyWord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
