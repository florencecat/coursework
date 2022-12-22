using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ICategoryRepository
    {
        List<categories> GetList();
        categories GetItem(Guid id);
        void CreateItem(categories item);
        void UpdateItem(categories item);
        categories DeleteItem(Guid id);
    }
}
