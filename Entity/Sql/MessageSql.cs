using System.ComponentModel.DataAnnotations;

namespace SimpleBot.Entity.Sql
{
    public class MessageSql
    {
        [Key]
        public int Id { get; set; }
        public string BotId { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}