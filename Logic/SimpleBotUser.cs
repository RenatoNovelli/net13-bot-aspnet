using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Repository;

namespace SimpleBot.Logic
{
    public static class SimpleBotUser
    {
        static IUserProfileRepository _userProfile;

        static SimpleBotUser()
        {
            _userProfile = new UserProfileMongoRepo();
        }

        public static string Reply(Message message)
        {
            var profile = _userProfile.GetProfile(message.Id);

            profile.Visitas++;

            _userProfile.SetProfile(profile);

            SaveMessage(message);

            return $"{message.User} disse '{message.Text}' e mandou {profile.Visitas} requisições";
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
            var mongoDb = new Repository.MongoDb();
            return mongoDb.GetUserProfile(id);
        }

        public static void SetProfile(UserProfile profile)
        {
            var mongoDb = new Repository.MongoDb();
            mongoDb.SaveUserProfile(profile);
        }

        public static UserProfile CreateProfile(UserProfile profile)
        {
            var mongoDb = new Repository.MongoDb();
            mongoDb.CreateUserProfile(profile);
            return profile;
        }
    }
}