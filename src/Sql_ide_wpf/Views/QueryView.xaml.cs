using GalaSoft.MvvmLight.Messaging;
using Sql_ide_wpf.Services;
using Sql_ide_wpf.Services.Customization;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.Commands;
using Sql_ide_wpf.Services.QueryEditor.Commands.EditingCommands;
using Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Sql_ide_wpf.Views
{
    /// <summary>
    /// Interaction logic for QueryView.xaml
    /// </summary>
    public partial class QueryView : UserControl
    {
        private ICommander _copyCommand;
        private ICommander _pasteCommand;
        private ICommander _undoCommand;
        private ITextBox _textBox;
        private TextBlock _textBlock;
        private CommandHistory _commandHistory;
        private QueryDefiner _queryDefiner;
        private KeyWordService _keywordService;
        private ButtonClickMessage message;
        public QueryView()
        {
            InitializeComponent();
            _textBox = new WindowsTextBox(QueryTextBox);
            _textBlock = QueryTextBlock;
            _commandHistory = new CommandHistory();
            _queryDefiner = new QueryDefiner(_textBox, _textBlock);
            _keywordService = new KeyWordService();
            _undoCommand = new UndoCommand(_textBox, _commandHistory);
            _copyCommand = new CopyCommand(_textBox);
            _pasteCommand = new PasteCommand(_textBox, _commandHistory);
        }
        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler(sender as Button);
        }

        private void ClickHandler(Button? clickedButton)
        {
            if (clickedButton != null)
            {
                message = new ButtonClickMessage { ButtonName = clickedButton.Name };
                Messenger.Default.Send(message);
            }
        }
    }
}
