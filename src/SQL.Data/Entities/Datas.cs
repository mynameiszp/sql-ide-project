using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("Data")]

    public class Datas : Exporting
    {
        public long Id { get; set; }
        [Column("Column_id")]
        public long ColumnId { get; set; }
        [MaxLength(100)]
        public string Input { get; set; }
        [Column("Row_id")]
        public long RowId { get; set; }

        public Datas(long columnId, string input, long rowId)
        {
            ColumnId = columnId;
            Input = input;
            RowId = rowId;
        }

        public void Accept(Visitor visitor)
        {
            visitor.VisitData(this);
        }
    }
}
