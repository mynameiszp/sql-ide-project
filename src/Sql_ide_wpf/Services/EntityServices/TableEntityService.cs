using Sql.Data.Repository;
using SQL.Data;
using SQL.Data.Entities;
using System.Collections.Generic;

namespace Sql_ide_wpf.Services.EntityServices
{
    public class TableEntityService
    {
        private ITableEntityRepository _repository;

        public TableEntityService()
        {
            _repository = new TableEntityRepository();
        }

        public IEnumerable<TableEntity> GetTableEntitiesList()
        {
            return _repository.GetTables();
        }

        public void AddToTableEntitiesList(TableEntity tableEntity)
        {
            _repository.InsertTable(tableEntity);
        }

        public TableEntity GetTable(long id)
        {
            return _repository.GetTableByID(id);
        }
        public void DeleteTable(TableEntity tableEntity)
        {
            _repository.DeleteTable(tableEntity);
        }
        public void DeleteAllColumns(TableEntity table)
        {
            _repository.DeleteAllColumns(table);
        }
        public TableEntity GetTableByName(string name)
        {
            return _repository.GetTableByName(name);
        }
        public void UpdateTable(TableEntity tableEntity)
        {
            _repository.UpdateTable(tableEntity);
        }
    }
}
