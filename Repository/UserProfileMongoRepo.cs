using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Logic;

namespace SimpleBot.Repository
{
    public class UserProfileMongoRepo : IUserProfileRepository
    {
        private IMongoCollection<UserProfileMongo> _collection;

        public UserProfileMongoRepo()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["connectionString"]);
            var db = client.GetDatabase("bot");
            var collection = db.GetCollection<UserProfileMongo>("profile");

            this._collection = collection;
        }

        public UserProfile GetProfile(string id)
        {
            var filter = new BsonDocument { { "_id", new BsonDocument { { "$eq", id } } } };

            var cursor = _collection.Find(filter);

            var profile = cursor.FirstOrDefault();

            return new UserProfile
            {
                Id = profile._id,
                Visitas = profile.Visitas
            };
        }

        public void SetProfile(UserProfile profile)
        {
            var filter = new BsonDocument { { "_id", new BsonDocument { { "$eq", profile.Id } } } };

            var doc = new UserProfileMongo
            {
                _id = profile.Id,
                Visitas = profile.Visitas
            };

            _collection.ReplaceOne(filter, doc, new UpdateOptions { IsUpsert = true });
        }
    }
}