using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IEventRepository
    {
        List<events> GetList();
        events GetItem(Guid id);
        void CreateItem(events item);
        void UpdateItem(events item);
        events DeleteItem(Guid id);
    }
}
