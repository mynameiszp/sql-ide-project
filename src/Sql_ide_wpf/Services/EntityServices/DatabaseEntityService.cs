using Sql.Data.Repository;
using SQL.Data;
using SQL.Data.Entities;
using System.Collections.Generic;

namespace Sql_ide_wpf.Services.EntityServices
{
    public class DatabaseEntityService
    {
        private IDatabaseEntityRepository _repository;

        public DatabaseEntityService()
        {
            _repository = new DatabaseEntityRepository();
        }

        public IEnumerable<DatabaseEntity> GetDatabaseEntitiesList()
        {
            return _repository.GetDatabases();
        }

        public void AddToDatabaseEntitiesList(DatabaseEntity databaseEntity)
        {
            _repository.InsertDatabase(databaseEntity);
        }

        public DatabaseEntity GetDatabase(int id)
        {
            return _repository.GetDatabaseByID(id);
        }

        public DatabaseEntity? GetDatabaseByName(string name)
        {
            return _repository.GetDatabaseByName(name);
        }

        public void UpdateDatabase(DatabaseEntity databaseEntity)
        {
            _repository.UpdateDatabase(databaseEntity);
        }
        public void DeleteDatabase(DatabaseEntity databaseEntity)
        {
            _repository.DeleteDatabase(databaseEntity);
        }

        public void DeleteAllSchemes(DatabaseEntity databaseEntity)
        {
            _repository.DeleteAllSchemes(databaseEntity);
        }
    }
}
