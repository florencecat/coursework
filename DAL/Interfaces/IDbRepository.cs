﻿using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IDbRepository
    {
        IRepository<users> Users { get; }
        IRepository<events> Events { get; }
        IRepository<reviews> Reviews { get; }
        IRepository<categories> Categories { get; }
        IRepository<accessLevels> AccessLevels { get; }
        IRepository<participations> Participations { get; }

        int Save();
    }
}
