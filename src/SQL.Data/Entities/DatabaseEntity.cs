using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("DatabaseEntities")]
    public class DatabaseEntity : Exporting
    {
        public long Id { get; set; }
        [MaxLength(70)]
        public string Name { get; set; }
        public DateOnly DateOfCreation { get; set; }
        [MaxLength(70)]
        public string DBType { get; set; }
        public List<SchemeEntity> Schemes { get; set; }

        public DatabaseEntity(string name, DateOnly dateOfCreation, string dBType)
        {
            Name = name;
            DateOfCreation = dateOfCreation;
            DBType = dBType;
            Schemes = new List<SchemeEntity>();
        }

        public void Accept(Visitor visitor)
        {
            visitor.VisitDatabase(this);
        }
    }
}
