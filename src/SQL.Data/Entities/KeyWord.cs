using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("KeyWords")]
    public class KeyWord
    {
        public long Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public KeyWord(string name)
        {
            Name = name;
        }
    }
}
