using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Entity.Mongo;
using SimpleBot.Logic;
using SimpleBot.Logic.Interfaces;

namespace SimpleBot.Repository
{
    public class MessageMongoRepo : IMessageRepository
    {
        private IMongoCollection<MessageMongo> _collectionMessage;

        public MessageMongoRepo()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["mongoConnectionString"]);
            var db = client.GetDatabase("bot");
            var collectionMessage = db.GetCollection<MessageMongo>("message");

            this._collectionMessage = collectionMessage;
        }

        public void SaveMessage(Message message)
        {
            var messageMongo = new MessageMongo
            {
                User = message.User,
                Text = message.Text
            };
        
            _collectionMessage.InsertOne(messageMongo);
        }

    }
}