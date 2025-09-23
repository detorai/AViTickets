using AVi.Models;
using Metsys.Bson;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AVi.Service
{
     public class UserService
        {
            private string GenerateSalt()
            {
                byte[] saltBytes = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }
                return Convert.ToBase64String(saltBytes);
            }

            private string HashPassword(string password, string salt)
            {
                using (var sha256 = SHA256.Create())
                {
                    var saltedPassword = password + salt;
                    var bytes = Encoding.UTF8.GetBytes(saltedPassword);
                    var hash = sha256.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }
            }

            public async Task<bool> RegisterUser(string phone, string password)
            {
                if (await Hepler.Database.Users.AnyAsync(u => u.UserPhone == phone))
                    return false;

                var salt = GenerateSalt();
                var passwordHash = HashPassword(password, salt);

                var user = new User
                {
                    UserPhone = phone,
                    UserRole = 1,
                    Passwordhash = passwordHash,
                    Salt = salt
                };

                Hepler.Database.Users.Add(user);
                await Hepler.Database.SaveChangesAsync();
                return true;
            }

            public async Task<User?> LoginUser(string phone, string password)
            {
                var user = await Hepler.Database.Users
                    .FirstOrDefaultAsync(u => u.UserPhone == phone);

                if (user == null) return null;

                var attemptedHash = HashPassword(password, user.Salt);

                if (attemptedHash == user.Passwordhash)
                    return user;

                return null;
            }
        }   
    
}
