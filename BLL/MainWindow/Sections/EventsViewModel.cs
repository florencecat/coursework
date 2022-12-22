using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.MainWindow.Sections
{
    public class EventsViewModel : ViewModelBase
    {
        private List<events> _eventsList;
        private List<users> _usersList;
        private List<categories> _categoriesList;

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

        public List<users> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        public List<categories> CategoriesList
        {
            get => _categoriesList;
            set
            {
                _categoriesList = value;
                OnPropertyChanged(nameof(CategoriesList));
            }
        }

        public EventsViewModel()
        {
            dbRepository = new DbRepository();

            EventsList = dbRepository.Events.GetList();
            UsersList = dbRepository.Users.GetList();
            CategoriesList = dbRepository.Categories.GetList();
        }
    }
}
