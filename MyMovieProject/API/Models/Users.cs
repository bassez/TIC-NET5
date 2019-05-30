using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace API.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Date_Created { get; set; }

        // FK
        // public Notes Notes { get; set; }
        // public Comments Comments { get; set; }
        // public Likes Likes { get; set; }


        public static string GenSalt(int size = 12) {
            var random = new RNGCryptoServiceProvider();
            var _salt = new Byte[size];
            random.GetBytes(_salt);
            var salt = Convert.ToBase64String(_salt);

            return salt;
        }

        public static string HashPassword(string password, string salt)
            {
                var combinedPassword = String.Concat(password, salt);
                var sha256 = new SHA256Managed();
                var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
                var hash = sha256.ComputeHash(bytes);
                var hashedPassword = Convert.ToBase64String(hash);

                return hashedPassword;
            }

        public static Boolean ValidatePassword(String enteredPassword, String storedHash, String storedSalt)
            {
                var hash = HashPassword(enteredPassword, storedSalt);
                return String.Equals(storedHash, hash);
            }
    }
}
