using Microsoft.Bot.Connector;
using MongoDB.Driver;
using SimpleBot.Logic;
using System.Configuration;
using System.Linq;

namespace SimpleBot.Repository
{
    public class MongoDb
    {
        private readonly IMongoDatabase _database;

        public MongoDb()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["connectionString"]);
            _database = client.GetDatabase("bot");
        }

        internal void SaveActivity(Activity activity)
        {
            var coll = _database.GetCollection<Activity>("activity");
            coll.InsertOne(activity);
        }

        internal void SaveUserProfile(UserProfile userProfile)
        {
            var coll = _database.GetCollection<UserProfile>("user_profile");

            var filter = Builders<UserProfile>.Filter.Where(x => x.Id == userProfile.Id);
            coll.ReplaceOne(filter, userProfile);
        }

        internal UserProfile GetUserProfile(string userId)
        {
            var coll = _database.GetCollection<UserProfile>("user_profile");
            var filter = Builders<UserProfile>.Filter.Eq(x => x.Id, userId);
            return coll.Find(filter).FirstOrDefault();
        }

        internal void CreateUserProfile(UserProfile userProfile)
        {
            var coll = _database.GetCollection<UserProfile>("user_profile");
            coll.InsertOne(userProfile);
        }
    }
}