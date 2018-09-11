using System;
using SimpleBot.Logic;
using SimpleBot.Logic.Interfaces;

namespace SimpleBot.Repository
{
    public class UserProfileMemoRepo : IUserProfileRepository
    {
        public UserProfile GetProfile(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void SetProfile(UserProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}