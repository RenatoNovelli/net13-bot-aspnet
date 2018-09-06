using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        public static string Reply(Message message)
        {
            SaveMessage(message);

            return $"{message.User} disse '{message.Text}'";
        }

        private static void SaveMessage(Message message)
        {
            var client = new MongoClient();
            var doc = new BsonDocument
            {
                { "id", message.Id },
                { "usuario", message.User },
                {"texto", message.Text },
                {"app", "bot_1.0" }
            };

            var db = client.GetDatabase("db01");
            var col = db.GetCollection<BsonDocument>("tabela01");
            col.InsertOne(doc);
        }

        public static UserProfile GetProfile(string id)
        {
            return null;
        }

        public static void SetProfile(string id, UserProfile profile)
        {
        }
    }
}