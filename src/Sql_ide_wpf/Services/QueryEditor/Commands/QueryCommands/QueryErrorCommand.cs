using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands
{
    public class QueryErrorCommand : ICommander
    {
        private TextBlock _textBlock;

        public QueryErrorCommand(TextBlock textBlock)
        {
            _textBlock = textBlock;
        }
        public void Execute()
        {
            _textBlock.Text = "Wrong syntax";
        }
    }
}