using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sql_ide_wpf.ViewModels
{
    public sealed class SchemeEntitiesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private SchemeEntityService _dataService;
        private ObservableCollection<SchemeEntity> _schemes;

        public SchemeEntitiesViewModel()
        {
            _dataService = new SchemeEntityService();
            LoadSchemes();
        }

        public ObservableCollection<SchemeEntity> Schemes
        {
            get { return _schemes; }
            set
            {
                _schemes = value;
                OnPropertyChanged("Schemes");
            }
        }

        private async void LoadSchemes()
        {
            Schemes = new ObservableCollection<SchemeEntity>(_dataService.GetSchemeEntitiesList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
