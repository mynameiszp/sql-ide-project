using Sql.Data.Repository;
using SQL.Data;
using SQL.Data.Entities;
using System.Collections.Generic;

namespace Sql_ide_wpf.Services.EntityServices
{
    public class SchemeEntityService
    {
        private ISchemeEntityRepository _repository;

        public SchemeEntityService()
        {
            _repository = new SchemeEntityRepository();
        }

        public IEnumerable<SchemeEntity> GetSchemeEntitiesList()
        {
            return _repository.GetSchemes();
        }

        public void AddToSchemeEntitiesList(SchemeEntity schemeEntity)
        {
            _repository.InsertScheme(schemeEntity);
        }

        public void DeleteAllTables(SchemeEntity schemeEntity)
        {
            _repository.DeleteAllTables(schemeEntity);
        }

        public SchemeEntity? GetScheme(int id)
        {
            return _repository.GetSchemeByID(id);
        }
        public SchemeEntity? GetSchemaByName(string name)
        {
            return _repository.GetSchemeByName(name);
        }

        public void UpdateScheme(SchemeEntity schemeEntity)
        {
            _repository.UpdateScheme(schemeEntity);
        }
        public void DeleteScheme(SchemeEntity schemeEntity)
        {
            _repository.DeleteScheme(schemeEntity);
        }
    }
}
