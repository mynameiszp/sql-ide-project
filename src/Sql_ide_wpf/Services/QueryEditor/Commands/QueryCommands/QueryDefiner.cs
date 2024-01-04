using GalaSoft.MvvmLight.Messaging;
using Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.CRUD;
using Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.Others;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands
{
    public class QueryDefiner
    {
        private ITextBox _textBox;
        private TextBlock _textBlock;
        public QueryDefiner(ITextBox textBox, TextBlock textBlock)
        {
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
            _textBox = textBox;
            _textBlock = textBlock;
        }

        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "Run")
            {
                RunCommand();
            }
        }
        private void RunCommand()
        {
            ICommander command;
            string query = _textBox.GetText().ToUpper();
            switch (query.Split(' ')[0])
            {
                case "CREATE":
                    command = new CreateCommand(_textBox.GetText(), _textBlock);
                    break;
                case "DROP":
                    command = new DropCommand(_textBox.GetText(), _textBlock);
                    break;
                case "INSERT":
                    command = new InsertCommand(_textBox.GetText(), _textBlock);
                    break;
                case "SELECT":
                    command = new SelectCommand(_textBox.GetText(), _textBlock);
                    break;
                case "UPDATE":
                    command = new UpdateCommand(_textBox.GetText(), _textBlock);
                    break;
                case "DELETE":
                    command = new DeleteCommand(_textBox.GetText(), _textBlock);
                    break;
                default:
                    command = new QueryErrorCommand(_textBlock);
                    break;
            }
            command.Execute();
        }
    }
}
