using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.EditingCommands
{
    public class Clipboard
    {
        private string _copiedText = "";
        private static Clipboard _instance;
        private Clipboard() { }
        public static Clipboard GetInstance()
        {
            if (_instance == null) { _instance = new Clipboard(); }
            return _instance;
        }
        public string GetCopiedText()
        {
            return _copiedText;
        }

        public void SetCopiedText(string text)
        {
            _copiedText = text;
        }
    }
}
