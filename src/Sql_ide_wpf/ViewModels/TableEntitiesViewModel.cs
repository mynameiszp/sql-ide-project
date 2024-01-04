using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sql_ide_wpf.ViewModels
{
    public sealed class TableEntitiesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private TableEntityService _dataService;
        private ObservableCollection<TableEntity> _tables;

        public TableEntitiesViewModel()
        {
            _dataService = new TableEntityService();
            LoadTables();
        }

        public ObservableCollection<TableEntity> Tables
        {
            get { return _tables; }
            set
            {
                _tables = value;
                OnPropertyChanged("Tables");
            }
        }

        private async void LoadTables()
        {
            Tables = new ObservableCollection<TableEntity>(_dataService.GetTableEntitiesList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
