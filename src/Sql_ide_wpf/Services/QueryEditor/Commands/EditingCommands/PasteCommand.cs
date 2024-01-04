using GalaSoft.MvvmLight.Messaging;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.EditingCommands
{
    public class PasteCommand : ICommander
    {
        private ITextBox _textBox;
        private CommandHistory _commandHistory;

        public PasteCommand(ITextBox textBox, CommandHistory commandHistory)
        {
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
            _textBox = textBox;
            _commandHistory = commandHistory;
        }
        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "Paste")
            {
                Execute();
            }
        }
        public void Execute()
        {
            var text = Clipboard.GetInstance().GetCopiedText();
            if (_textBox.PasteText(text))
            {
                _commandHistory.push(this);
            }
        }
    }
}
