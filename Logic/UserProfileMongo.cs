using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBot.Logic
{
    [BsonIgnoreExtraElements]
    public class UserProfileMongo
    {
        public string _id { get; set; }

        public int Visitas { get; set; }

        [BsonExtraElements]
        public BsonDocument Outros { get; set; }
    }
}