using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string password);
        void CreatePasswordForUser(NetworkCredential credential);
        users GetItemByUsername(string Username);
        List<users> GetList();
        users GetItem(Guid id);
        void CreateItem(users item);
        void UpdateItem(users item);
        users DeleteItem(Guid id);
    }
}
