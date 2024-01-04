using Microsoft.EntityFrameworkCore;
using SQL.Data.Entities;

namespace SQL.Data
{
    public class SqlDataContext : DbContext
    {
        private static SqlDataContext _instance;
        private SqlDataContext() {}
        public static SqlDataContext GetSqlDataContext()
        {
            if (_instance == null)
            {
                _instance = new SqlDataContext();
            }
            return _instance;
        }
        public DbSet<DatabaseEntity> Databases { get; set; }
        public DbSet<SchemeEntity> Schemes { get; set; }
        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<ColumnEntity> Columns { get; set; }
        public DbSet<Datas> Data { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=sql-ide-database;");
        }
    }
}
