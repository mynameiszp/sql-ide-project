using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Data.Entities
{
    [Table("UserPreferences")]

    public class UserPreference
    {
        public long Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string PreferenceValue { get; set; }
        public UserPreference(string name, string preferenceValue)
        {
            Name = name;
            PreferenceValue = preferenceValue;            
        }
    }
}
