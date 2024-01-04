using SQL.Data.Entities;
using SQL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL.Data.Repository;

namespace Sql_ide_wpf.Services.EntityServices
{
    public class DataService
    {
        private IDataRepository _repository;

        public DataService()
        {
            _repository = new DataRepository();
        }

        public IEnumerable<Datas> GetDataList()
        {
            return _repository.GetDatas();
        }

        public void AddToDataList(Datas data)
        {
            _repository.InsertData(data);
        }

        public void DeleteFromDataList(Datas data)
        {
            _repository.DeleteData(data);
        }

        public Datas GetData(int id)
        {
            return _repository.GetDataByID(id);
        }

        public void UpdateData(Datas data)
        {
            _repository.UpdateData(data);
        }
    }
}
