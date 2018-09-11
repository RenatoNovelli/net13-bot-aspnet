using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBot.Entity.Mongo
{
    [BsonIgnoreExtraElements]
    public class UserProfileMongo
    {
        public string _id { get; set; }

        public int Visitas { get; set; }
    }
}