using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class ReviewsRepository : IRepository<reviews>
    {
        private EventsContext eventsContext = new EventsContext();

        public ReviewsRepository(EventsContext eventsContext) { this.eventsContext = eventsContext; }

        public void CreateItem(reviews item) { }
        public reviews DeleteItem(Guid id)
        {
            reviews review = eventsContext.reviews.Find(id);
            if (review != null)
            {
                eventsContext.reviews.Remove(review);
                return review;
            }

            return default;
        }

        public reviews GetItem(Guid id) => eventsContext.reviews.Find(id);
        public List<reviews> GetList() => eventsContext.reviews.ToList();
        public void UpdateItem(reviews item) { }
    }
}
