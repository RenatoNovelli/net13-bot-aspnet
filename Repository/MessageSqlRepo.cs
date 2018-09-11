using SimpleBot.Entity.Sql;
using SimpleBot.Entity.Sql.Context;
using SimpleBot.Logic;
using SimpleBot.Logic.Interfaces;

namespace SimpleBot.Repository
{
    public class MessageSqlRepo : IMessageRepository
    {
        public void SaveMessage(Message message)
        {
            var messageSql = new MessageSql
            {
                BotId = message.Id,
                Text = message.Text,
                User = message.User
            };

            using (var ctx = new SqlContext())
            {
                ctx.Message.Add(messageSql);
            };
        }
    }
}