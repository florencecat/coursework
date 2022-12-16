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
        //private EventsRepository eventsRepository;
        //private ReviewsRepository reviewsRepository;
        //private CategoriesRepository categoriesRepository;
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

        public IRepository<events> Events => throw new NotImplementedException();

        public IRepository<reviews> Reviews => throw new NotImplementedException();

        public IRepository<categories> Categories => throw new NotImplementedException();

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
