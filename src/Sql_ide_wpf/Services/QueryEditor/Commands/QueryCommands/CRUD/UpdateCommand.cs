using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.CRUD
{
    public class UpdateCommand : ICommander
    {
        private string query;
        private TextBlock _textBlock;
        private TableEntityService _tableEntityService;
        private ColumnEntityService _columnEntityService;
        private DataService _dataService;
        public UpdateCommand(string originalQuery, TextBlock textBlock)
        {
            query = originalQuery.Trim();
            _textBlock = textBlock;
            Initialize();
        }
        public void Execute()
        {
            TableEntity? table;
            string[] queryStrings = query.Split(' ');
            bool hasValidLength = queryStrings.Length >= 4;
            bool hasSemicolon = queryStrings[queryStrings.Length - 1].TrimEnd().Last().Equals(';');
            if (hasSemicolon && hasValidLength)
            {
                bool hasSetWord = queryStrings[2].ToUpper().Equals("SET");
                table = _tableEntityService.GetTableByName(queryStrings[1].Trim());
                if (hasSetWord && queryStrings.Length == 4 && table != null)
                {
                    string columnName = queryStrings[3].Substring(0, queryStrings[3].IndexOf("="));
                    int start = queryStrings[3].IndexOf("=") + 2;
                    int end = queryStrings[3].Length - 2;
                    string value = queryStrings[3].Substring(start, end - start);
                    UpdateAll(table, columnName, value);
                }
                else if (hasSetWord && queryStrings.Length > 4 && table != null)
                {
                    UpdateSelected(table);
                }
                else ShowErrorMessage();
            }
            else ShowErrorMessage();
        }

        private void UpdateAll(TableEntity table, string columnName, string value)
        {
            List<string> columnNames = table.Columns.Select(column => column.Name).ToList();
            if (columnNames.Contains(columnName))
            {
                ColumnEntity? column = table.Columns.Cast<ColumnEntity>().FirstOrDefault(column => column.Name == columnName);
                if (column != null)
                {
                    foreach (Datas data in _dataService.GetDataList())
                    {
                        if (data.ColumnId == column.Id)
                        {
                            data.Input = value;
                            _dataService.UpdateData(data);
                        }
                    }
                    _textBlock.Text = "Data updated";
                }
                else ShowErrorMessage();
            }
            else ShowErrorMessage();
        }

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
        private void UpdateSelected(TableEntity table) { }
    }
}