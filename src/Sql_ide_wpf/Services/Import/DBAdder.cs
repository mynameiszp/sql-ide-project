using GalaSoft.MvvmLight.Messaging;
using Sql_ide_wpf.ViewModels;

namespace Sql_ide_wpf.Services.Import
{
    public class DBAdder
    {
        private Importer _importer;
        public DBAdder(Importer importer)
        {
            _importer = importer; 
        }
        public void ImportDB()
        {
            _importer.Import();
        }
    }
}
