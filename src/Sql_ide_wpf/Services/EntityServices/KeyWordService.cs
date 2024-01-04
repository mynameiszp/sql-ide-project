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
    public class KeyWordService
    {
        private IKeyWordRepository _repository;

        public KeyWordService()
        {
            _repository = new KeyWordRepository();
        }

        public IEnumerable<KeyWord> GetKeyWordEntitiesList()
        {
            return _repository.GetKeyWords();
        }

        public void AddToKeyWordEntitiesList(KeyWord keyWord)
        {
            _repository.InsertKeyWord(keyWord);
        }

        public KeyWord GetKeyWord(int id)
        {
            return _repository.GetKeyWordByID(id);
        }

        public KeyWord? GetKeyWordByName(string name)
        {
            return _repository.GetKeyWordByName(name);
        }

        public void UpdateKeyWord(KeyWord keyWord)
        {
            _repository.UpdateKeyWord(keyWord);
        }
    }
}
