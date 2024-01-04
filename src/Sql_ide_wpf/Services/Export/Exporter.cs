using GalaSoft.MvvmLight.Messaging;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sql_ide_wpf.Services.Export
{
    public class Exporter
    {
        private DataService _dataService;
        private DatabaseEntityService _databaseEntityService;

        public Exporter()
        {
            _dataService = new DataService();
            _databaseEntityService = new DatabaseEntityService();
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
        }
        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "ExportDb")
            {
                ExportDb();
            }
        }

        private void ExportDb()
        {
            //hardcoded, must come from ui

            List<Exporting> entities = new List<Exporting>();
            var database = _databaseEntityService.GetDatabaseEntitiesList().LastOrDefault();
            if (database != null)
            {
                entities.Add(database);
                entities.AddRange(database.Schemes);
                entities.AddRange(_dataService.GetDataList());
            }

            Visitor visitor = new DatabaseExporter();

            foreach (Exporting entity in entities)
            {
                entity.Accept(visitor);
            }

            SaveFile(visitor);
        }
        private void SaveFile(Visitor visitor)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "database"; // Default file name
            dlg.DefaultExt = ".sql"; // Default file extension
            dlg.Filter = "SQL Files|*.sql"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                File.WriteAllText(dlg.FileName, visitor.GetResult());
            }
        }
    }
}
