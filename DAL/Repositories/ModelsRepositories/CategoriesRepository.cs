using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    internal class CategoriesRepository : IRepository<categories>
    {
        EventsContext eventsContext;

        public CategoriesRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(categories item)
        {
            eventsContext.categories.Add(item);
        }

        public categories DeleteItem(Guid id)
        {
            categories category = eventsContext.categories.Find(id);

            if (category != null)
                eventsContext.categories.Remove(category);

            return category;
        }

        public categories GetItem(Guid id) => eventsContext.categories.Find(id);

        public List<categories> GetList() => eventsContext.categories.ToList();

        public void UpdateItem(categories item)
        {
            eventsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            eventsContext.SaveChanges();
        }
    }
}
