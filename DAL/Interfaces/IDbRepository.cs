using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IDbRepository
    {
        IUserRepository Users { get; }
        IEventRepository Events { get; }
        IRepository<reviews> Reviews { get; }
        ICategoryRepository Categories { get; }
        IAccessRepository AccessLevels { get; }
        IRepository<participations> Participations { get; }

        int Save();
    }
}
