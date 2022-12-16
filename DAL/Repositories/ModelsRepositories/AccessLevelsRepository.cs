using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class AccessLevelsRepository : IAccessRepository
    {
        EventsContext eventsContext;

        public AccessLevelsRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }
        public accessLevels GetItem(Guid id) => eventsContext.accessLevels.Find(id);
        public List<accessLevels> GetList() => eventsContext.accessLevels.ToList();
    }
}
