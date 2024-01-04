using Microsoft.EntityFrameworkCore;
using SQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL.Data.Repository
{
    public class UserPreferenceRepository : IUserPreferenceRepository
    {
        private bool disposedValue = false;
        private SqlDataContext _context;
        public UserPreferenceRepository()
        {
            _context = SqlDataContext.GetSqlDataContext();
        }
        public void DeleteUserPreference(UserPreference userPreference)
        {
            _context.UserPreferences.Remove(userPreference);
            Save();
        }

        public UserPreference GetUserPreferenceByID(int userPreferenceID)
        {
            return _context.UserPreferences.Find(userPreferenceID);
        }

        public UserPreference? GetUserPreferenceByName(string userPreferenceName)
        {
            return _context.UserPreferences.FirstOrDefault(s => s.Name == userPreferenceName);
        }

        public IEnumerable<UserPreference> GetUserPreferences()
        {
            return _context.UserPreferences.ToList();
        }

        public void InsertUserPreference(UserPreference userPreference)
        {
            _context.UserPreferences.Add(userPreference);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUserPreference(UserPreference userPreference)
        {
            _context.Entry(userPreference).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
