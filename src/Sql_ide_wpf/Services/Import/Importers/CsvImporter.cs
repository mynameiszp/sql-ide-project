using GalaSoft.MvvmLight.Messaging;
using System;

namespace Sql_ide_wpf.Services.Import.Importers
{
    public class CsvImporter : Importer
    {
        public CsvImporter()
        {
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
        }
        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "ImportCSV")
            {
                Import();
            }
        }
        public void Import()
        {
            throw new NotImplementedException();
        }
    }
}
