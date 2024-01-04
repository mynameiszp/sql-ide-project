using SQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL.Data.Repository
{
    public interface IDataRepository
    {
        IEnumerable<Datas> GetDatas();
        Datas GetDataByID(int dataID);
        void InsertData(Datas data);
        void DeleteData(Datas data);
        void UpdateData(Datas data);
        void Save();
    }
}
