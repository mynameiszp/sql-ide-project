using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.TextBoxes
{
    public class WindowsTextBox : ITextBox
    {
        private TextBox _textBox;
        public WindowsTextBox(TextBox textBox)
        {
            _textBox = textBox;
        }
        public string GetSelectedText()
        {
            return _textBox.SelectedText;
        }

        public string GetText()
        {
            return _textBox.Text;
        }

        public bool PasteText(string text)
        {
            _textBox.Text = _textBox.Text.Insert(_textBox.CaretIndex, text);
            return true;
        }

        public void ReplaceText(string text)
        {
            _textBox.Text = text;
        }

        public bool Undo()
        {
            _textBox.Undo();
            return true;
        }
    }
}
