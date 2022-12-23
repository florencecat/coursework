using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Services
{
    public class EventService
    {
        private UserService userService;
        private DbRepository dbRepository;

        public EventService()
        {
            userService = new UserService();
            dbRepository = new DbRepository();
        }
        public void CreateEvent(events @event)
        {
            @event.author = userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).id;

            dbRepository.Events.UpdateItem(@event);
        }
    }
}
