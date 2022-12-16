using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        T GetItem(Guid id);
        void CreateItem(T item);
        void UpdateItem(T item);
        T DeleteItem(Guid id);
    }
}
