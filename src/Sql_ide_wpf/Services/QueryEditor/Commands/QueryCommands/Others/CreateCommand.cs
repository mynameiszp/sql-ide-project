using SQL.Data;
using Sql_ide_wpf.Services.EntityServices;
using Sql_ide_wpf.Services.QueryEditor.TextBoxes;
using SQL.Data.Entities;
using System.Windows.Controls;
using System;

namespace Sql_ide_wpf.Services.QueryEditor.Commands.QueryCommands.Others
{
    public class CreateCommand : ICommander
    {
        DatabaseEntityService databaseEntityService;
        private string query;
        private TextBlock _textBlock;

        public CreateCommand(string originalQuery, TextBlock textBlock)
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
                        databaseEntityService.AddToDatabaseEntitiesList(new DatabaseEntity(name, DateOnly.FromDateTime(DateTime.Now), ""));
                        if (databaseEntityService.GetDatabaseByName(name) == null)
                            ShowErrorMessage();
                        else
                            _textBlock.Text = "Database created";
                        break;
                    default:
                        ShowErrorMessage();
                        break;
                }
            }
            else ShowErrorMessage();
        }
        private void Initialize()
        {
            databaseEntityService = new DatabaseEntityService();
        }
        private void ShowErrorMessage()
        {
            _textBlock.Text = ("Error occured");
        }
    }
}