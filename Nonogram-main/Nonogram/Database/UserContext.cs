using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Nonogram.Models;

namespace Nonogram.Database
{
    interface IUser
    {
        public void Save(User user, string filePath);
        public List<User> GetUsers(string filePath);
    }


    public class JsonUserDatabase : IUser
    {
        public List<User> GetUsers(string filePath)
        {
            Debug.WriteLine("GetUsers");

            if (!File.Exists(filePath))
                return new List<User>();

            Debug.WriteLine("True");

            string json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<User>();

            List<User> tmp = JsonSerializer.Deserialize<List<User>>(json);
            return tmp;
        }

        public void Save(User user, string filePath)
        {
            Debug.WriteLine("test");
            List<User> users = GetUsers(filePath);
            users.Add(user);

            string json = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, json);
        }
    }


    class UserContext
    {
        private readonly string _connectionString;
        public UserContext(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void StoreUser(User user)
        {
            List<User> users = GetAllUsers() ?? [];
            users.Add(user);

            string jsonUserString = JsonSerializer.Serialize(users);

            File.WriteAllText(jsonUserString, _connectionString);
        }

        public List<User> GetAllUsers()
        {
            string jsonString = File.ReadAllText(_connectionString);
            return JsonSerializer.Deserialize<List<User>>(jsonString);
        }
    }
}
