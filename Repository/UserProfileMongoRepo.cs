using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Entity.Mongo;
using SimpleBot.Logic;
using SimpleBot.Logic.Interfaces;

namespace SimpleBot.Repository
{
    public class UserProfileMongoRepo : IUserProfileRepository
    {
        private IMongoCollection<UserProfileMongo> _collectionProfile;

        public UserProfileMongoRepo()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["mongoConnectionString"]);
            var db = client.GetDatabase("bot");
            var collectionProfile = db.GetCollection<UserProfileMongo>("profile");

            this._collectionProfile = collectionProfile;
        }

        public UserProfile GetProfile(string id)
        {
            var userProfile = new UserProfile
            {
                Id = id
            };

            var filter = new BsonDocument { { "_id", new BsonDocument { { "$eq", id } } } };

            var cursor = _collectionProfile.Find(filter);

            var profile = cursor.FirstOrDefault();

            userProfile.Visitas = profile != null ? profile.Visitas : 0;

            return userProfile;

        }

        public void SetProfile(UserProfile profile)
        {
            var filter = Builders<UserProfileMongo>.Filter.Where(x => x._id == profile.Id);

            var doc = new UserProfileMongo
            {
                _id = profile.Id,
                Visitas = profile.Visitas
            };

            _collectionProfile.ReplaceOne(filter, doc, new UpdateOptions { IsUpsert = true });
        }
    }
}