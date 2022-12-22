using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private EventsContext eventsContext;

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

        public void CreatePasswordForUser(NetworkCredential credential)
        {
            users user = GetItemByUsername(credential.UserName);

            user.password = HashPassword(credential.Password);

            UpdateItem(user);
        }
        public users GetItemByUsername(string Username)
        {
            return eventsContext.users.Where(u => u.nickname == Username).FirstOrDefault();
        }

        //Inherited methods
        public UsersRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(users item) { eventsContext.users.Add(item); }

        public users GetItem(Guid id) => eventsContext.users.Find(id);

        public List<users> GetList() => eventsContext.users.ToList();
        public users DeleteItem(Guid id)
        {
            users user = eventsContext.users.Find(id);
            if (user != null)
            {
                eventsContext.users.Remove(user);
                return user;
            }

            return default;
        }
        public void UpdateItem(users item) 
        { 
            eventsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            eventsContext.SaveChanges();
        }
    }
}
