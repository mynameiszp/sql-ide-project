using SQL.Data.Entities;
using SQL.Data;
using Sql_ide_wpf.Services.EntityServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sql_ide_wpf.ViewModels
{
    public class DataViewModel : ViewModelBase
    {
        private DataService _dataService;
        private ObservableCollection<Datas> _datas;

        public DataViewModel()
        {
            _dataService = new DataService();
            LoadDatas();
        }

        public ObservableCollection<Datas> Datas
        {
            get { return _datas; }
            set
            {
                _datas = value;
                OnPropertyChanged("Datas");
            }
        }

        private async void LoadDatas()
        {
            Datas = new ObservableCollection<Datas>(_dataService.GetDataList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
