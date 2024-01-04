using SQL.Data.Entities;
using SQL.Data;
using Sql_ide_wpf.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_ide_wpf.ViewModels
{
    public sealed class KeyWordsViewModel: ViewModelBase
    {
        private KeyWordService _dataService;
        private ObservableCollection<KeyWord> _keywords;

        public KeyWordsViewModel()
        {
            _dataService = new KeyWordService();
            LoadKeyWords();
        }

        public ObservableCollection<KeyWord> KeyWords
        {
            get { return _keywords; }
            set
            {
                _keywords = value;
                OnPropertyChanged("KeyWords");
            }
        }

        private async void LoadKeyWords()
        {
            KeyWords = new ObservableCollection<KeyWord>(_dataService.GetKeyWordEntitiesList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
