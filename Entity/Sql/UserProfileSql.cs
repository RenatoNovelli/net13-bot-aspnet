using System.ComponentModel.DataAnnotations;

namespace SimpleBot.Entity.Sql
{
    public class UserProfileSql
    {
        [Key]
        public int Id { get; set; }

        public string BotId { get; set; }

        public int Visitas { get; set; }
    }
}