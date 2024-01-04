namespace SQL.Data.Entities
{
    public interface Visitor
    {
        void VisitDatabase(DatabaseEntity databaseEntity);
        void VisitScheme(SchemeEntity schemeEntity);
        void VisitData(Datas data);
        string GetResult();
    }
}
