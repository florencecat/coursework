using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class UserService
    {
        private DbRepository dbRepository;

        public UserService()
        {
            this.dbRepository = new DbRepository();
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }

            if (buffer3 == null && buffer4 == null)
            {
                return true;
            }
            if (buffer3 == null || buffer4 == null || buffer3.Length != buffer4.Length)
            {
                return false;
            }
            for (var i = 0; i < buffer3.Length; i++)
            {
                if (buffer3[i] != buffer4[i]) return false;
            }
            return true;
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            users user = GetItemByUsername(credential.UserName);

            if (user != null && VerifyHashedPassword(user.password, credential.Password))
                return true;

            return false;
        }
        public string CreatePasswordForUser(NetworkCredential credential)
        {
            users user = GetItemByUsername(credential.UserName);

            user.password = HashPassword(credential.Password);

            dbRepository.Users.UpdateItem(user);

            return user.password;
        }
        public users GetItemByUsername(string Username)
        {
            return dbRepository.Users.GetList().Where(u => u.nickname == Username).FirstOrDefault();
        }
    }
}
