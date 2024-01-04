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
    public sealed class UserPreferencesViewModel: ViewModelBase
    {
        private UserPreferenceService _dataService;
        private ObservableCollection<UserPreference> _userPreferences;

        public UserPreferencesViewModel()
        {
            _dataService = new UserPreferenceService();
            LoadUserPreferences();
        }

        public ObservableCollection<UserPreference> UserPreferences
        {
            get { return _userPreferences; }
            set
            {
                _userPreferences = value;
                OnPropertyChanged("UserPreferences");
            }
        }

        private async void LoadUserPreferences()
        {
            UserPreferences = new ObservableCollection<UserPreference>(_dataService.GetUserPreferencesList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
