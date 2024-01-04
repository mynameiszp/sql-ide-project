using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sql_ide_wpf.ViewModels
{
    public sealed class ColumnEntitiesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ColumnEntityService _dataService;
        private ObservableCollection<ColumnEntity> _columns;

        public ColumnEntitiesViewModel()
        {
            _dataService = new ColumnEntityService();
            LoadColumns();
        }

        public ObservableCollection<ColumnEntity> Columns
        {
            get { return _columns; }
            set
            {
                _columns = value;
                OnPropertyChanged("Columns");
            }
        }

        private async void LoadColumns()
        {
            Columns = new ObservableCollection<ColumnEntity>(_dataService.GetColumnEntitiesList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
