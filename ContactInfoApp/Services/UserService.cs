using ContactInfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoApp.Services
{
    public class UserService
    {

        public List<User> GetUsers()
        {

            return new List<User>()
            {
                new User() { Id = 1, Name = "John", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'M', ProfilePicture ="dotnet_bot.png" },
                new User() { Id = 2, Name = "Johny", Address = "1st Street", Email = "Johny@gmail.com", MobileNumber = "1234567890", Sex = 'M' , ProfilePicture ="dotnet_bot.png"},
                new User() { Id = 3, Name = "Rick", Address = "1st Street", Email = "Rick@gmail.com", MobileNumber = "1234567890", Sex = 'M', ProfilePicture ="dotnet_bot.png" },
                new User() { Id = 4, Name = "Monty", Address = "1st Street", Email = "Monty@gmail.com", MobileNumber = "1234567890", Sex = 'F', ProfilePicture ="dotnet_bot.png" },
                new User() { Id = 5, Name = "Jack", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'M' , ProfilePicture ="dotnet_bot.png"},
                new User() { Id = 6, Name = "Paul", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'M' , ProfilePicture ="dotnet_bot.png"},
                new User() { Id = 7, Name = "Nina", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'F', ProfilePicture ="dotnet_bot.png" },
                new User() { Id = 8, Name = "Nina", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'F' , ProfilePicture ="dotnet_bot.png"},
                new User() { Id = 9, Name = "Nina", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'F' , ProfilePicture ="dotnet_bot.png"},

            };
        }

        public User GetUser(int id)
        {
                return GetUsers().FirstOrDefault(q => q.Id == id);
        }

    }
}
