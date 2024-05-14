using AirApi.Database.Interface;
using AirApi.Model;
using LiteDB;

namespace AirApi.Database
{
    public class DataBase : IDataContext
    {
        private LiteDatabase _db = new LiteDatabase("data.db");
        private const string _USERS = "Users";
        public void AddUser(User user)
        {
            _db.GetCollection<User>(_USERS).Insert(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>(_USERS).FindAll();
        }

        public IEnumerable<User> GetUsersByWord(string word)
        {
            return _db.GetCollection<User>(_USERS).FindAll().Where(s => s.UserName.ToLower().Contains(word.ToLower()));
        }

        public User GetUserById(int id)
        {
            return _db.GetCollection<User>(_USERS).FindById(id);
        }

        public void DeleteUser(int id)
        {
            _db.GetCollection<User>(_USERS).Delete(id);
        }
    }
}