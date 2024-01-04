using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.CRUD
{
    public class InsertCommand : ICommander
    {
        private string query;
        private TextBlock _textBlock;
        private TableEntityService _tableEntityService;
        private ColumnEntityService _columnEntityService;
        private DataService _dataService;
        public InsertCommand(string originalQuery, TextBlock textBlock)
        {
            query = originalQuery.Trim();
            _textBlock = textBlock;
            Initialize();
        }

        public void Execute()
        {
            TableEntity? table;
            string[] queryStrings = query.Split(' ');
            bool hasIntoKeyword = queryStrings[1].ToUpper().Equals("INTO");
            bool hasValuesKeyword = query.ToUpper().Contains("VALUES");
            bool hasSemicolon = queryStrings[queryStrings.Length - 1].TrimEnd().Last().Equals(';');
            bool tableExists = _tableEntityService.GetTableByName(queryStrings[2]) != null;

            if (hasIntoKeyword && hasValuesKeyword && hasSemicolon && tableExists)
            {
                table = _tableEntityService.GetTableByName(queryStrings[2]);
                if (queryStrings[3].ToUpper().Equals("VALUES"))
                {
                    InsertAllValues(table.Columns, FormatStringForValues(query));
                }
                else
                {
                    InsertSelectedValues(table, query, queryStrings);
                }
            }
            else ShowErrorMessage();
        }

        private void InsertAllValues(List<ColumnEntity> columns, string[] array)
        {
            if (columns.Count == array.Count())
            {
                long lastDataRowId = GetLastDataRowId(_dataService.GetDataList());
                for (int i = 0; i < columns.Count; i++)
                {
                    _dataService.AddToDataList(new Datas(columns[i].Id, array[i], lastDataRowId + 1));
                }
                _textBlock.Text = ("Your data have been succesfully added");
            }
            else ShowErrorMessage();
        }
        private void InsertSelectedValues(TableEntity table, string query, string[] array)
        {
            if (array[3].Contains("("))
            {
                string[] queryColumns = FormatStringForColumns(query);
                int startIndex = query.ToUpper().LastIndexOf("VALUES");
                string[] queryValues = FormatStringForValues(query.Substring(startIndex));
                if (queryColumns.Length == queryValues.Length)
                {
                    long lastDataRowId = GetLastDataRowId(_dataService.GetDataList());
                    long[] columnsId = new long[queryColumns.Length];
                    List<string> columnNames = _tableEntityService.GetTable(table.Id).Columns.Select(column => column.Name).ToList();
                    for (long i = 0; i < queryColumns.Length; i++)
                    {
                        if (columnNames.Contains(queryColumns[i]))
                        {
                            columnsId[i] = _columnEntityService.GetColumnByName(queryColumns[i]).Id;
                        }
                        else
                        {
                            ShowErrorMessage();
                            return;
                        }
                    }
                    if (!columnsId.Contains(-1))
                    {
                        for (int i = 0; i < queryColumns.Length; i++)
                        {
                            _dataService.AddToDataList(new Datas(columnsId[i], queryValues[i], lastDataRowId + 1));
                        }
                        _textBlock.Text = ("Your data have been succesfully added");
                    }
                    else ShowErrorMessage();
                }
                else ShowErrorMessage();
            }
            else ShowErrorMessage();
        }

        private string[] FormatStringForValues(string originalQuery)
        {
            int start = originalQuery.IndexOf('(') + 1;
            int end = originalQuery.IndexOf(')');
            string trimmed = originalQuery.Substring(start, end - start);
            return trimmed.Split(',').Select(s => s.Trim().Trim('\'')).ToArray();
        }

        private string[] FormatStringForColumns(string originalQuery)
        {
            int start = originalQuery.IndexOf('(') + 1;
            int end = originalQuery.IndexOf(')');
            string trimmed = originalQuery.Substring(start, end - start);
            return trimmed.Split(',').Select(s => s.Trim()).ToArray();
        }

        private long GetLastDataRowId(IEnumerable<Datas> list)
        {
            long result = 0;
            if (list.Count() > 0) result = list.Last().RowId;
            return result;
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
    }
}