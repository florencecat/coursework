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
    public class UsersRepository : IRepository<users>
    {
        private EventsContext eventsContext;

        //Inherited methods
        public UsersRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(users item) 
        { 
            eventsContext.users.Add(item);

            eventsContext.SaveChanges();
        }

        public users GetItem(Guid id) => eventsContext.users.Find(id);

        public List<users> GetList() => eventsContext.users.ToList();
        public users DeleteItem(Guid id)
        {
            users user = eventsContext.users.Find(id);
            if (user != null)
            {
                eventsContext.users.Remove(user);

                eventsContext.SaveChanges();

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
