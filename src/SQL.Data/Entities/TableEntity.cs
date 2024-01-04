using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("TableEntities")]

    public class TableEntity
    {
        public long Id { get; set; }
        [MaxLength(70)]
        public string Name { get; set; }
        public List<ColumnEntity> Columns { get; set; }

        public TableEntity(string name)
        {
            Name = name;
            Columns = new List<ColumnEntity>();
        }
    }
}
