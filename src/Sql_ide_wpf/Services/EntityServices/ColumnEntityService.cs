using Sql.Data.Repository;
using SQL.Data;
using SQL.Data.Entities;
using System.Collections.Generic;

namespace Sql_ide_wpf.Services.EntityServices
{
    public class ColumnEntityService
    {
        private IColumnEntityRepository _repository;

        public ColumnEntityService()
        {
            _repository = new ColumnEntityRepository();
        }

        public IEnumerable<ColumnEntity> GetColumnEntitiesList()
        {
            return _repository.GetColumns();
        }

        public void AddToColumnEntitiesList(ColumnEntity columnEntity)
        {
            _repository.InsertColumn(columnEntity);
        }

        public ColumnEntity GetColumn(int id)
        {
            return _repository.GetColumnByID(id);
        }
        public ColumnEntity GetColumnByName(string name)
        {
            return _repository.GetColumnByName(name);
        }
        public void UpdateColumn(ColumnEntity columnEntity)
        {
            _repository.UpdateColumn(columnEntity);
        }
    }
}
