using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    internal class ParticipationsRepository : IRepository<participations>
    {
        EventsContext eventsContext = new EventsContext();

        public ParticipationsRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(participations item) { }

        public participations DeleteItem(Guid id)
        {
            participations participation = eventsContext.participations.Find(id);
            if (participation != null)
            {
                eventsContext.participations.Remove(participation);
                return participation;
            }

            return default;
        }

        public participations GetItem(Guid id) => eventsContext.participations.Find(id);

        public List<participations> GetList() => eventsContext.participations.ToList();

        public void UpdateItem(participations item) { }
    }
}
