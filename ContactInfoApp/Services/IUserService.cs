using ContactInfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
