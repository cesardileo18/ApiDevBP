using SQLite;
using System.Text.Json.Serialization;

namespace ApiDevBP.Core.Domain
{
    [Table("Users")]
    public class UserDomain
    {
        [PrimaryKey, AutoIncrement]
        [JsonIgnore] // Ignora esta propiedad para la serialización
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
