using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Models
{
    public class User
    {
        const int keySize = 64;
        const int iterations = 350000;
        static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string Name { get; private set; }
        public DPassword Password { get; private set; }

        public User(string name, DPassword password)
        {
            Name = name;
            Password = password;
        }

        // https://code-maze.com/csharp-hashing-salting-passwords-best-practices/
        public static DPassword HashPassword(string password1, string password2)
        {
            if (password1 != password2)
                throw new ArgumentException("Passwords do not match!");

            byte[] salt = RandomNumberGenerator.GetBytes(keySize); 

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password1),
                salt,
                iterations,
                hashAlgorithm,
                keySize
            );

            return new DPassword(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public static bool VerifyPassword(string password, DPassword dPassword)
        {
            byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password,
                //dPassword.Salt,
                Convert.FromBase64String(dPassword.Salt),
                iterations,
                hashAlgorithm,
                keySize
            );

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromBase64String(dPassword.Hash));
        }
    }

    //class DPassword(string hash, string salt)
    //{
    //    public string Hash { get; private set; } = hash;
    //    public string Salt { get; private set; } = salt;
    //}
    public class DPassword(string hash, string salt)
    {
        public string Hash { get; private set; } = hash;
        public string Salt { get; private set; } = salt;
    }
}
