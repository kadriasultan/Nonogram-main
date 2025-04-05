using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Nonogram.Models;

namespace Nonogram.Services
{
    public static class UserService
    {
        private static readonly string usersFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Users.json");

        public static List<User> LoadUsers()
        {
            try
            {
                if (File.Exists(usersFilePath))
                {
                    var json = File.ReadAllText(usersFilePath);
                    return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                }
            }
            catch (Exception ex)
            {
                // Log error (in een echte app zou je dit willen loggen)
                Console.WriteLine($"Error loading users: {ex.Message}");
            }

            return new List<User>();
        }

        public static void SaveUsers(List<User> users)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    // Andere opties indien nodig
                };

                var json = JsonSerializer.Serialize(users, options);
                File.WriteAllText(usersFilePath, json);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error saving users: {ex.Message}");
                throw; // Re-throw of handleer dit op een andere manier
            }
        }
    }
}