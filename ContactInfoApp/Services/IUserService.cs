using ContactInfoApp.Models;

namespace ContactInfoApp.Services
{
    public interface IUserService
    {
        List<User> GetUsers();

        User GetUser(int id);

        int DeleteUser(int id);

        void AddUser(User user);

        void UpdateUser(User user);
    }
}
