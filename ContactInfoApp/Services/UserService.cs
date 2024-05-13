using ContactInfoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoApp.Services
{
    public class UserService : IUserService
    {

        private SQLiteConnection _connection;
        private readonly string _dbPath;
        public string StatusMessage;
        int result = 0;

        public UserService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if(_connection != null) { return; }
            _connection = new SQLiteConnection(_dbPath);

            _connection.CreateTable<User>();

        }

        public List<User> GetUsers()
        {
            try
            {
                Init();
                return _connection.Table<User>().ToList(); 
            }
            catch (Exception) 
            {
                StatusMessage = "Unable to get the data";
            }
            return new List<User>();
        }

        public User GetUser(int id)
        {
            try
            {
                Init();
                return _connection.Table<User>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }
            return null;
        }

        public int DeleteUser(int id)
        {
            try
            {
                Init();
                return _connection.Table<User>().Delete(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data.";
            }
            return 0;
        }

        public void AddUser(User user)
        {
            try
            {
                Init();

                if (user == null)
                    throw new Exception("Invalid user Record");

                result = _connection.Insert(user);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to Insert data.";
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                Init();

                if (user == null)
                    throw new Exception("Invalid Causer Record");

                result = _connection.Update(user);
                StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to Update data.";
            }
        }


        /*
        public List<User> GetUsers()
        {

            return new List<User>()
            {
                new User() { Id = 1, Name = "John", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'M', ProfilePicture ="pic1.jpg" },
                new User() { Id = 2, Name = "Johny", Address = "1st Street", Email = "Johny@gmail.com", MobileNumber = "1234567890", Sex = 'M' , ProfilePicture ="pic2.jpg"},
                new User() { Id = 3, Name = "Rick", Address = "1st Street", Email = "Rick@gmail.com", MobileNumber = "1234567890", Sex = 'M', ProfilePicture ="pic3.jpg" },
                new User() { Id = 4, Name = "Monty", Address = "1st Street", Email = "Monty@gmail.com", MobileNumber = "1234567890", Sex = 'F', ProfilePicture ="pic4.jpg" },
                new User() { Id = 5, Name = "Jack", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'M' , ProfilePicture ="pic1.jpg"},
                new User() { Id = 6, Name = "Paul", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'M' , ProfilePicture ="dotnet_bot.png"},
                new User() { Id = 7, Name = "Nina", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'F', ProfilePicture ="dotnet_bot.png" },
                new User() { Id = 8, Name = "Nina", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'F' , ProfilePicture ="dotnet_bot.png"},
                new User() { Id = 9, Name = "Nina", Address = "1st Street", Email = "John@gmail.com", MobileNumber = "1234567890", Sex = 'F' , ProfilePicture ="https://images.pexels.com/photos/34534/people-peoples-homeless-male.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"},

            };
        }


        public User GetUser(int id)
        {
                return GetUsers().FirstOrDefault(q => q.Id == id);
        }

        */

    }
}
