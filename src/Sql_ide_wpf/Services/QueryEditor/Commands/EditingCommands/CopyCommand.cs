using GalaSoft.MvvmLight.Messaging;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.EditingCommands
{
    public class CopyCommand : ICommander
    {
        private ITextBox _textBox;
        private string _copiedText;
        public CopyCommand(ITextBox textBox)
        {
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
            _textBox = textBox;
        }
        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "Copy")
            {
                Execute();
            }
        }
        public void Execute()
        {
            _copiedText = _textBox.GetSelectedText();
            Clipboard.GetInstance().SetCopiedText(_copiedText);
        }
    }
}
