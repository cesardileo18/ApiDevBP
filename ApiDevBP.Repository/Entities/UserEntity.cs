using SQLite;
using System.Text.Json.Serialization;

namespace ApiDevBP.Repository.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
