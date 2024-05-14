using AirApi.Model;

namespace AirApi.Database.Interface
{
    public interface IDataContext
    {
        void AddUser(User user);
        User GetUserById(int id);
        void DeleteUser(int id);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersByWord(string word);
    }
}
