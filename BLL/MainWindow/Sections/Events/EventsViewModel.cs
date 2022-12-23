using Model.Models;
using Model.Repositories;
using Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModel.MainWindow.Sections
{
    public class EventsViewModel : ViewModelBase
    {
        private List<events> _eventsList;
        private List<users> _usersList;
        private List<categories> _categoriesList;
        private users _selectedUser;
        private events _selectedEvent;
            
        public Window _currentDialogWindow;

        private DbRepository dbRepository;
        private UserService userService;

        public users SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
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
        public events SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }
        

        public EventsViewModel()
        {
            dbRepository = new DbRepository();
            userService = new UserService();

            EventsList = dbRepository.Events.GetList();

            AddEvent = new RelayCommand(ExecuteAddEvent);
            DeleteEvent = new RelayCommand(ExecuteDeleteEvent, CanExecuteDeleteEvent);
            UpdateEvent = new RelayCommand(ExecuteUpdateEvent, CanExecuteUpdateEvent);
        }

        public ICommand AddEvent { get; set; }
        private void ExecuteAddEvent(object obj)
        {
            _currentDialogWindow.IsVisibleChanged += (s, ev) =>
            {
                if (_currentDialogWindow.IsVisible == false && _currentDialogWindow.IsLoaded)
                    _currentDialogWindow.Close();

            };

            _currentDialogWindow.ShowDialog();

            EventsList = dbRepository.Events.GetList();
        }

        public ICommand DeleteEvent { get; set; }
        private void ExecuteDeleteEvent(object obj)
        {
            dbRepository.Events.DeleteItem(SelectedEvent.id);

            EventsList = dbRepository.Events.GetList();
        }
        private bool CanExecuteDeleteEvent(object obj)
        {
            if (userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).accessLevels.name == "Manager" ||
                SelectedEvent == null)
                return false;

            return true;
        }

        public ICommand UpdateEvent { get; set; }
        private void ExecuteUpdateEvent(object obj)
        {
            ((EventUpdateViewModel)(_currentDialogWindow.DataContext)).Event = SelectedEvent;

            _currentDialogWindow.IsVisibleChanged += (s1, ev1) =>
            {
                if (_currentDialogWindow.IsVisible == false && _currentDialogWindow.IsLoaded)
                {
                    _currentDialogWindow.Close();
                }

            };

            _currentDialogWindow.ShowDialog();

            dbRepository.Events.UpdateItem(((EventUpdateViewModel)(_currentDialogWindow.DataContext)).Event);
            EventsList = dbRepository.Events.GetList();
        }

        private bool CanExecuteUpdateEvent(object obj)
        {
            if (SelectedEvent != null)
                if (SelectedEvent.users.id == userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).id)
                    return true;

            if (userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).accessLevels.name == "Manager" || SelectedEvent == null)
                return false;

            return true;
        }
    }
}
