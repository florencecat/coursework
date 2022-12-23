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
        private ReviewsRepository reviewsRepository;
        private CategoriesRepository categoriesRepository;
        private AccessLevelsRepository accessLevelsRepository;
        private ParticipationsRepository participationsRepository;

        public DbRepository()
        {
            eventsContext = new EventsContext();
        }

        public IRepository<users> Users
        {
            get
            {
                if(usersRepository == null)
                    usersRepository = new UsersRepository(eventsContext);

                return usersRepository;
            }
        }

        public IRepository<events> Events
        {
            get
            {
                if (eventsRepository == null)
                    eventsRepository = new EventsRepository(eventsContext);

                return eventsRepository;
            }
        }

        public IRepository<reviews> Reviews
        {
            get
            {
                if (reviewsRepository == null)
                    reviewsRepository = new ReviewsRepository(eventsContext);

                return reviewsRepository;
            }
        }

        public IRepository<categories> Categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepository(eventsContext);

                return categoriesRepository;
            }
        }

        public IRepository<accessLevels> AccessLevels
        {
            get
            {
                if (accessLevelsRepository == null)
                    accessLevelsRepository = new AccessLevelsRepository(eventsContext);

                return accessLevelsRepository;
            }
        }

        public IRepository<participations> Participations
        {
            get
            {
                if (participationsRepository == null)
                    participationsRepository = new ParticipationsRepository(eventsContext);

                return participationsRepository;
            }
        }

        public int Save() => this.eventsContext.SaveChanges();
    }
}
