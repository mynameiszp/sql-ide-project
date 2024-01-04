
using SQL.Data.Entities;

namespace Sql_ide_wpf.Services.Export
{
    public class DatabaseExporter : Visitor
    {
        private string result = "";
        public string GetResult()
        {
            return result;
        }
        public void VisitData(Datas data)
        {
            result += "\n" + "data insertion";
        }

        public void VisitDatabase(DatabaseEntity databaseEntity)
        {
            result += "Database name: " + databaseEntity.Name + "\n" +
                      "Date of creation: " + databaseEntity.DateOfCreation.ToShortDateString() + "\n" +
                      "Database type: " + databaseEntity.DBType + "\n";
        }

        public void VisitScheme(SchemeEntity schemeEntity)
        {
            result += "\n" + "Scheme name: " + schemeEntity.Name + "\n";
            foreach (TableEntity table in schemeEntity.Tables)
            {
                //instead of this generate script for creating table
                result += "\n" + "Table name: " + table.Name + "\n";
            }
        }
    }
}
