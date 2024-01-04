using GalaSoft.MvvmLight.Messaging;
using SQL.Data;
using SQL.Data.Entities;
using Sql_ide_wpf.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sql_ide_wpf.Services.Import.Importers
{
    public class SqlImporter : Importer
    //works for postgres .sql file
    {
        private DatabaseEntityService _databaseEntityService;

        public SqlImporter()
        {
            Messenger.Default.Register<ButtonClickMessage>(this, MessageReceived);
            Initialize();
        }
        private void MessageReceived(ButtonClickMessage message)
        {
            if (message.ButtonName == "ImportSQL")
            {
                Import();
            }
        }

        public void Import()
        {
            string content = ReadFile(OpenFile());
            if (content != null)
            {
                DatabaseEntity databaseEntity = new DatabaseEntity("NewDatabase", DateOnly.FromDateTime(DateTime.Now), "PostgreSQL");
                List<string> tableQueries = new List<string>();
                string startKeyword = "Type: TABLE; Schema: ";
                string endKeyword = ");";
                int startIndex = 0;
                while ((startIndex = content.IndexOf(startKeyword, startIndex)) != -1)
                {
                    startIndex += startKeyword.Length;
                    int endIndex = content.IndexOf(endKeyword, startIndex);
                    if (endIndex == -1) break;
                    tableQueries.Add(content.Substring(startIndex, endIndex - startIndex + 2));
                    startIndex = endIndex;
                }

                foreach (string query in tableQueries)
                {
                    string end = "; Owner: ";
                    string schemaName = query.Substring(0, query.IndexOf(end));
                    bool containsSchema = false;
                    foreach (SchemeEntity schemeEntity in databaseEntity.Schemes)
                    {
                        if (schemeEntity.Name == schemaName)
                        {
                            containsSchema = true;
                            break;
                        }
                    }
                    if (!containsSchema)
                    {
                        SchemeEntity schemeEntity = CreateScheme(databaseEntity, schemaName);
                        CreateTable(databaseEntity.Schemes.FirstOrDefault(schemeEntity), query);
                    }
                    else
                    {
                        SchemeEntity? schema = databaseEntity.Schemes.FirstOrDefault(scheme => scheme.Name == schemaName);
                        CreateTable(schema, query);
                    }
                }
                _databaseEntityService.AddToDatabaseEntitiesList(databaseEntity);
            }


        }
        private string OpenFile()
        {
            string filename = "";
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "database"; // Default file name
            dlg.DefaultExt = ".sql"; // Default file extension
            dlg.Filter = "SQL Files|*.sql"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }
            return filename;
        }

        private string ReadFile(string filename)
        {
            if (File.Exists(filename))
            {
                return File.ReadAllText(filename);
            }
            else
            {
                return null;
            }
        }

        private SchemeEntity CreateScheme(DatabaseEntity database, string name)
        {
            SchemeEntity schemeEntity = new SchemeEntity(name);
            database.Schemes.Add(schemeEntity);
            return schemeEntity;
        }

        private void CreateTable(SchemeEntity? schemeEntity, string query)
        {
            if (schemeEntity != null)
            {
                int startname = query.IndexOf(schemeEntity.Name + ".");
                int endname = query.IndexOf("(");
                string tableName = query.Substring(startname, endname - startname);
                Dictionary<string, string> data = GetDataFromQuery(query);
                TableEntity tableEntity = new TableEntity(tableName); //hardcoded id
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        ColumnEntity columnEntity = new ColumnEntity(item.Key, item.Value);
                        tableEntity.Columns.Add(columnEntity);
                    }
                }
                schemeEntity.Tables.Add(tableEntity);
            }
        }

        private Dictionary<string, string> GetDataFromQuery(string query)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            int startColumns = query.IndexOf("(\r\n") + 5;
            int endColumns = query.IndexOf("\r\n);");
            string columns = query.Substring(startColumns, endColumns - startColumns);
            foreach (string line in columns.Split(",\r\n"))
            {
                string[] arr = line.Trim().Split(" ");
                if (arr[0].Trim() != "CONSTRAINT")
                {
                    result.Add(arr[0].Trim(), arr[1].Trim());
                }
            }
            return result;
        }

        private void Initialize()
        {
            _databaseEntityService = new DatabaseEntityService();
        }
    }
}
