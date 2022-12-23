using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    internal class EventsRepository : IRepository<events>
    {
        EventsContext eventsContext;

        public EventsRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(events item)
        {
            eventsContext.events.Add(item);

            eventsContext.SaveChanges();
        }

        public events DeleteItem(Guid id)
        {
            events @event = eventsContext.events.Find(id);

            if (@event != null)
                eventsContext.events.Remove(@event);

            eventsContext.SaveChanges();

            return @event;
        }

        public events GetItem(Guid id) => eventsContext.events.Find(id);

        public List<events> GetList() => eventsContext.events.ToList();

        public void UpdateItem(events item)
        {
            eventsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;

            eventsContext.SaveChanges();
        }
    }
}
