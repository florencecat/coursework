using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class DbRepository : IDbRepository
    {
        private EventsContext eventsContext;

        private UsersRepository usersRepository;
        private EventsRepository eventsRepository;
        //private ReviewsRepository reviewsRepository;
        private CategoriesRepository categoriesRepository;
        private AccessLevelsRepository accessLevelsRepository;
        //private ParticipationsRepository participationsRepository;

        public DbRepository()
        {
            eventsContext = new EventsContext();
        }

        public IUserRepository Users
        {
            get
            {
                if(usersRepository == null)
                    usersRepository = new UsersRepository(eventsContext);

                return usersRepository;
            }
        }

        public IEventRepository Events
        {
            get
            {
                if (eventsRepository == null)
                    eventsRepository = new EventsRepository(eventsContext);

                return eventsRepository;
            }
        }

        public IRepository<reviews> Reviews => throw new NotImplementedException();

        public ICategoryRepository Categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepository(eventsContext);

                return categoriesRepository;
            }
        }

        public IAccessRepository AccessLevels
        {
            get
            {
                if (accessLevelsRepository == null)
                    accessLevelsRepository = new AccessLevelsRepository(eventsContext);

                return accessLevelsRepository;
            }
        }

        public IRepository<participations> Participations => throw new NotImplementedException();

        public int Save() => this.eventsContext.SaveChanges();
    }
}
