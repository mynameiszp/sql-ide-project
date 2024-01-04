using SQL.Data.Entities;
using Sql.Data.Repository;
using SQL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL.Data.Repository;

namespace Sql_ide_wpf.Services.EntityServices
{
    public class UserPreferenceService
    {
        private IUserPreferenceRepository _repository;

        public UserPreferenceService()
        {
            _repository = new UserPreferenceRepository();
        }

        public IEnumerable<UserPreference> GetUserPreferencesList()
        {
            return _repository.GetUserPreferences();
        }

        public void AddToUserPreferencesList(UserPreference userPreference)
        {
            _repository.InsertUserPreference(userPreference);
        }

        public UserPreference GetUserPreference(int id)
        {
            return _repository.GetUserPreferenceByID(id);
        }

        public UserPreference? GetUserPreferenceByName(string name)
        {
            return _repository.GetUserPreferenceByName(name);
        }

        public void UpdateUserPreference(UserPreference userPreference)
        {
            _repository.UpdateUserPreference(userPreference);
        }
    }
}
