using Model.Models;
using System.Collections.Generic;
using System;

namespace Model.Interfaces
{
    public interface IAccessRepository
    {
        List<accessLevels> GetList();
        accessLevels GetItem(Guid id);
    }
}