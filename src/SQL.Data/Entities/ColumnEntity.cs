using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("ColumnEntities")]

    public class ColumnEntity
    {
        public long Id { get; set; }
        [MaxLength(70)]
        public string Name { get; set; }
        public string Type { get; set; }
        public ColumnEntity(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}