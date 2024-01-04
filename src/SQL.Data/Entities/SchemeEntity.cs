using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("SchemeEntities")]

    public class SchemeEntity : Exporting
    {
        public long Id { get; set; }
        [MaxLength(70)]
        public string Name { get; set; }
        public List<TableEntity> Tables { get; set; }

        public SchemeEntity(string name)
        {
            Name = name;
            Tables = new List<TableEntity>();
        }

        public void Accept(Visitor visitor)
        {
            visitor.VisitScheme(this);
        }
    }
}
