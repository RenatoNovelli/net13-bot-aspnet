namespace SimpleBot.Logic.Interfaces
{
    public interface IUserProfileRepository
    {
        UserProfile GetProfile(string id);

        void SetProfile(UserProfile profile);
    }
}
