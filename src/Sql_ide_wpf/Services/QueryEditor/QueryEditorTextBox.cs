using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Sql_ide_wpf.Services.QueryEditor
{
    public class QueryEditorTextBox
    {
        public string GetSelection(TextBoxBase textBox)
        {
            return ((TextBox)textBox).SelectedText;
        }

        public bool PasteSelection(TextBoxBase textBox, string selection)
        {
            ((TextBox)textBox).Text = ((TextBox)textBox).Text.Insert(((TextBox)textBox).SelectionStart, selection);
            return true;
        }

        public bool Undo(TextBoxBase textBox)
        {
            ((TextBox)textBox).Undo();
            return true;
        }
    }
}
