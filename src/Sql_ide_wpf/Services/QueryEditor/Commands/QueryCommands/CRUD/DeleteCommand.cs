using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.CRUD
{
    public class DeleteCommand : ICommander
    {
        private string query;
        private TextBlock _textBlock;
        private TableEntityService _tableEntityService;
        private ColumnEntityService _columnEntityService;
        private DataService _dataService;
        public DeleteCommand(string originalQuery, TextBlock textBlock)
        {
            query = originalQuery.Trim();
            _textBlock = textBlock;
            Initialize();
        }
        public void Execute()
        {
            TableEntity? table;            
            string[] queryStrings = query.Split(' ');
            bool hasSemicolon = queryStrings[queryStrings.Length - 1].TrimEnd().Last().Equals(';');
            if (hasSemicolon)
            {
                bool hasFromKeyword = queryStrings[1].ToUpper().Equals("FROM");
                if (hasFromKeyword && queryStrings.Length == 3)
                {
                    table = _tableEntityService.GetTableByName(queryStrings[2].Trim().Substring(0, queryStrings[2].Length - 1));
                    if (table != null) TruncateTable(table);
                    else ShowErrorMessage();
                }
                else if (hasFromKeyword && queryStrings.Length > 3 && queryStrings[3].ToUpper().Equals("WHERE"))
                {
                    table = _tableEntityService.GetTableByName(queryStrings[2].Trim());
                    if (table != null) DeleteFromTable(table);
                    else ShowErrorMessage();
                }
                else ShowErrorMessage();
            }
            else ShowErrorMessage();
        }

        private void TruncateTable(TableEntity table)
        {
            List<ColumnEntity> columnList = table.Columns;
            foreach (Datas data in _dataService.GetDataList())
            {
                if (columnList.Select(column => column.Id).ToList().Contains(data.ColumnId))
                {
                    _dataService.DeleteFromDataList(data);
                }
            }
            _textBlock.Text = "Table truncated";
            var s = _dataService.GetDataList();
        }

        private void DeleteFromTable(TableEntity table) {}

        private void ShowErrorMessage()
        {
            _textBlock.Text = ("Wrong syntax");
        }
        private void Initialize()
        {
            _tableEntityService = new TableEntityService();
            _columnEntityService = new ColumnEntityService();
            _dataService = new DataService();
        }
    }
}