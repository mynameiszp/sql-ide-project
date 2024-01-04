using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.Others
{
    public class DropCommand : ICommander
    {
        DatabaseEntityService databaseEntityService;
        SchemeEntityService schemeEntityService;
        TableEntityService tableEntityService;
        DataService dataService;
        private string query;
        private TextBlock _textBlock;
        public DropCommand(string originalQuery, TextBlock textBlock)
        {
            Initialize();
            query = originalQuery.Trim();
            _textBlock = textBlock;
        }
        public void Execute()
        {
            if (query.Split(' ').Length == 3 && query[query.Length - 1].Equals(';'))
            {
                string name = "";
                switch (query.Split(' ')[1].ToUpper())
                {
                    case "DATABASE":
                        name = query.Split(' ')[2].Substring(0, query.Split(' ')[2].Length - 1);
                        DatabaseEntity? database = databaseEntityService.GetDatabaseByName(name);
                        if (database != null)
                        {
                            DeleteDbCascade(database);
                            if (databaseEntityService.GetDatabaseByName(name) == null)
                                _textBlock.Text = "Database dropped";
                            else
                                ShowErrorMessage();
                        }
                        else
                            ShowErrorMessage();
                        break;
                    default:
                        ShowErrorMessage();
                        break;
                }
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void DeleteDbCascade(DatabaseEntity database)
        {
            List<SchemeEntity> schemeList = database.Schemes.ToList();
            List<TableEntity> tableList = database.Schemes.SelectMany(scheme => scheme.Tables).ToList();
            List<ColumnEntity> columnList = database.Schemes.SelectMany(scheme => scheme.Tables).SelectMany(table => table.Columns).ToList();

            foreach (Datas data in dataService.GetDataList())
            {
                if (columnList.Select(column => column.Id).ToList().Contains(data.ColumnId))
                {
                    dataService.DeleteFromDataList(data);
                }
            }
            tableList.ForEach(table => tableEntityService.DeleteAllColumns(table));
            schemeList.ForEach(scheme => schemeEntityService.DeleteAllTables(scheme));
            databaseEntityService.DeleteAllSchemes(database);
            databaseEntityService.DeleteDatabase(database);
        }

        private void Initialize()
        {
            databaseEntityService = new DatabaseEntityService();
            schemeEntityService = new SchemeEntityService();
            tableEntityService = new TableEntityService();
            dataService = new DataService();
        }
        private void ShowErrorMessage()
        {
            _textBlock.Text = ("Error occured");
        }
    }
}