using System.Data.Entity;

namespace SimpleBot.Entity.Sql.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base("sqlConnectionString")
        {

        }

        public DbSet<UserProfileSql> UserProfile { get; set; }
        public DbSet<MessageSql> Message { get; set; }
    }
}