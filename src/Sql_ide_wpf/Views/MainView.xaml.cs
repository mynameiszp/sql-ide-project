using GalaSoft.MvvmLight.Messaging;
using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services;
using Sql_ide_wpf.Services.Customization;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.Export;
using Sql_ide_wpf.Services.Import;
using Sql_ide_wpf.Services.Import.Importers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sql_ide_wpf.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private IEnumerable<DatabaseEntity> _databaseEntitiesList;
        private AppCustomization _customization;
        private DBAdder _dBSqlAdder;
        private DBAdder _dBCsvAdder;
        private DataService _dataService;
        private ButtonClickMessage _message;
        private Exporter _exporter;

        public MainView()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _dataService = new DataService();
            _customization = new AppCustomization();
            _customization.Subscribe(new AppTheme());
            _customization.Subscribe(new AppFont());
            _dBSqlAdder = new DBAdder(new SqlImporter());
            _dBCsvAdder = new DBAdder(new CsvImporter());
            _exporter = new Exporter();
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }

        private void Import_Sql_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }

        private void Import_Csv_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }
        private void DarkThemeGothic_Click(object sender, RoutedEventArgs e)
        {
            _customization.NotifyAll(new List<Uri>() { new Uri("Customizations/Themes/Dark.xaml", UriKind.Relative),
                                                       new Uri("Customizations/Fonts/MSGothic.xaml", UriKind.Relative) });
        }
        private void DarkThemeTimes_Click(object sender, RoutedEventArgs e)
        {
            _customization.NotifyAll(new List<Uri>() { new Uri("Customizations/Themes/Dark.xaml", UriKind.Relative),
                                                       new Uri("Customizations/Fonts/TimesNewRoman.xaml", UriKind.Relative) });
        }
        private void LightThemeGothic_Click(object sender, RoutedEventArgs e)
        {
            _customization.NotifyAll(new List<Uri>() { new Uri("Customizations/Themes/Light.xaml", UriKind.Relative),
                                                       new Uri("Customizations/Fonts/MSGothic.xaml", UriKind.Relative) });
        }
        private void LightThemeTimes_Click(object sender, RoutedEventArgs e)
        {
            _customization.NotifyAll(new List<Uri>() { new Uri("Customizations/Themes/Light.xaml", UriKind.Relative),
                                                       new Uri("Customizations/Fonts/TimesNewRoman.xaml", UriKind.Relative) });
        }
        private void ClickHandler(Button? clickedButton)
        {
            if (clickedButton != null)
            {
                _message = new ButtonClickMessage { ButtonName = clickedButton.Name };
                Messenger.Default.Send(_message);
            }
        }
    }
}
