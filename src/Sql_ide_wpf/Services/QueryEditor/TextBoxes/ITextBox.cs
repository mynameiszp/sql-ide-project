namespace Sql_ide_wpf.Services.QueryEditor.TextBoxes
{
    public interface ITextBox
    {
        public string GetSelectedText();
        public bool PasteText(string selection);
        public bool Undo();
        public string GetText();
        public void ReplaceText(string text);
    }
}
