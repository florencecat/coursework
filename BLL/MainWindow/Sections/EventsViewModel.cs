using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.MainWindow.Sections
{
    public class EventsViewModel : ViewModelBase
    {
        private List<events> _eventsList;
        private DbRepository dbRepository;

        public List<events> EventsList 
        { 
            get => _eventsList; 
            set
            {
                _eventsList = value;
                OnPropertyChanged(nameof(EventsList));
            }
        }

        public EventsViewModel()
        {
            dbRepository = new DbRepository();

            EventsList = dbRepository.Events.GetList();
        }
    }
}
