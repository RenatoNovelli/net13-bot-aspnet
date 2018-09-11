using SimpleBot.Logic.Interfaces;
using SimpleBot.Repository;

namespace SimpleBot.Logic
{
    public static class SimpleBotUser
    {
        static IUserProfileRepository _userProfile;
        static IMessageRepository _message;

        static SimpleBotUser()
        {
            //_userProfile = new UserProfileMongoRepo();
            //_message = new MessageMongoRepo();
            _userProfile = new UserProfileSqlRepo();
            _message = new MessageSqlRepo();
        }

        public static string Reply(Message message)
        {
            var profile = _userProfile.GetProfile(message.Id);

            profile.Visitas++;

            _userProfile.SetProfile(profile);

            _message.SaveMessage(message);

            return $"{message.User} disse '{message.Text}' e mandou {profile.Visitas} requisições";
        }

    }
}