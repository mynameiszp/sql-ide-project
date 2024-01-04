using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sql_ide_wpf.ViewModels
{
    public sealed class DatabaseEntitiesViewModel : ViewModelBase
    {
        private DatabaseEntityService _dataService;
        private ObservableCollection<DatabaseEntity> _databases;

        public DatabaseEntitiesViewModel()
        {
            _dataService = new DatabaseEntityService();
            LoadDatabases();
        }

        public ObservableCollection<DatabaseEntity> Databases
        {
            get { return _databases; }
            set
            {
                _databases = value;
                OnPropertyChanged("Databases");
            }
        }

        public async void LoadDatabases()
        {
            Databases = new ObservableCollection<DatabaseEntity>(_dataService.GetDatabaseEntitiesList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
