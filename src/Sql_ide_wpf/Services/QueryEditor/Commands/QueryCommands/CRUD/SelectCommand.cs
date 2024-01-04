using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.CRUD
{
    public class SelectCommand : ICommander
    {
        private string query;
        private TextBlock _textBlock;
        private TableEntityService _tableEntityService;
        private ColumnEntityService _columnEntityService;
        private DataService _dataService;
        public SelectCommand(string originalQuery, TextBlock textBlock)
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
                bool hasValidLength = queryStrings.Length >= 4 && queryStrings.Length < 6;
                bool isSelectAllQuery = queryStrings[1].Equals("*");
                bool hasFromKeyword = queryStrings[2].ToUpper().Equals("FROM");
                bool containsSemicolon = queryStrings[3].Contains(";");
                bool a = _tableEntityService.GetTableByName(queryStrings[3].Substring(0, queryStrings[3].Length - 1).Trim()) != null;
                bool b = _tableEntityService.GetTableByName(queryStrings[3]) != null;
                bool tableExists = containsSemicolon ? a : b;

                if (hasValidLength && isSelectAllQuery && hasFromKeyword && tableExists)
                {
                    table = containsSemicolon ?
                    _tableEntityService.GetTableByName(queryStrings[3].Substring(0, queryStrings[3].Length - 1).Trim()) :
                    _tableEntityService.GetTableByName(queryStrings[3]);
                    SelectAllValues(table);
                }
                else if (!isSelectAllQuery && query.ToUpper().Contains("FROM"))
                {
                    int start = query.ToUpper().LastIndexOf("FROM");
                    int end = query.IndexOf(";");
                    string tableName = query.Substring(start, end - start).Trim();
                    if (_tableEntityService.GetTableByName(tableName) != null)
                    {
                        table = _tableEntityService.GetTableByName(tableName);
                        SelectChosenValues();
                    }
                    else ShowErrorMessage();
                }
                else ShowErrorMessage();
            }
            else ShowErrorMessage();
        }

        private void SelectAllValues(TableEntity table)
        {
            Dictionary<long, List<string>> columnValues = new Dictionary<long, List<string>>();
            List<long> columnIds = table.Columns.Select(column => column.Id).ToList();

            HashSet<Datas> datas = new HashSet<Datas>();

            foreach (Datas item in _dataService.GetDataList())
            {
                if (columnIds.Contains(item.ColumnId))
                {
                    datas.Add(item);
                }
            }

            foreach (Datas item in datas)
            {
                if (!columnValues.ContainsKey(item.RowId))
                {
                    columnValues.Add(item.RowId, new List<string>());
                    columnValues.GetValueOrDefault(item.RowId)?.Add(item.Input);
                }
                else
                {
                    columnValues.GetValueOrDefault(item.RowId)?.Add(item.Input);
                }
            }
            PrintAllValues(table, columnValues);
        }

        private void PrintAllValues(TableEntity table, Dictionary<long, List<string>> values)
        {
            string title = "Table name: " + table.Name;
            string columns = "\n| ";
            string dottedLine = "\n" + new string('-', 10 * table.Columns.Count);
            string data = "";
            foreach (ColumnEntity column in table.Columns)
            {
                columns += column.Name + " | ";
            }

            if (values.Count > 0)
            {
                foreach (var item in values)
                {
                    data += "\n| ";
                    foreach (var value in item.Value)
                    {
                        if (value.Trim() == "")
                        {
                            data += "   " + " | ";
                        }
                        else data += value + " | ";
                    }
                }
            }
            _textBlock.Text = (title + columns + dottedLine + data);
        }
        private void SelectChosenValues() { }
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