using SQL.Data.Entities;

namespace Sql.Data.Repository
{
    public interface ISchemeEntityRepository : IDisposable
    {
        IEnumerable<SchemeEntity> GetSchemes();
        SchemeEntity? GetSchemeByID(long schemeID);
        SchemeEntity? GetSchemeByName(string schemeName);
        void InsertScheme(SchemeEntity scheme);
        void DeleteAllTables(SchemeEntity scheme);
        void DeleteScheme(SchemeEntity scheme);
        void UpdateScheme(SchemeEntity scheme);
        void Save();
    }
}
