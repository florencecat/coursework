using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class AccessLevelsRepository : IRepository<accessLevels>
    {
        EventsContext eventsContext;

        public AccessLevelsRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(accessLevels item) { }
        public accessLevels DeleteItem(Guid id) => null;
        public accessLevels GetItem(Guid id) => eventsContext.accessLevels.Find(id);
        public List<accessLevels> GetList() => eventsContext.accessLevels.ToList();
        public void UpdateItem(accessLevels item) {  }
    }
}
