using GalaSoft.MvvmLight.Messaging;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.EditingCommands
{
    public class UndoCommand : ICommander
    {
        private ITextBox _textBox;
        private CommandHistory _commandHistory;
         
        public UndoCommand(ITextBox textBox, CommandHistory commandHistory)
        {
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
            _textBox = textBox;
            _commandHistory = commandHistory;
        }
        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "Undo")
            {
                Execute();
            }
        }
        public void Execute()
        {
            if (_textBox.Undo())
            {
                _commandHistory.pop();
            }
        }
    }
}
