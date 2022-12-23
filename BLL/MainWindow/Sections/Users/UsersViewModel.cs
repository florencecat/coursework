using Model.Models;
using Model.Repositories;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModel.MainWindow.Sections
{
    public class UsersViewModel : ViewModelBase
    {
        private List<users> _usersList;
        private users _selectedUser;

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

        public List<users> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        public UsersViewModel()
        {
            userService = new UserService();
            dbRepository = new DbRepository();

            UsersList = dbRepository.Users.GetList();

            AddUser = new RelayCommand(ExecuteAddUser, CanExecuteAddUser);
            UpdateUser = new RelayCommand(ExecuteUpdateUser, CanExecuteUpdateUser);
            DeleteUser = new RelayCommand(ExecuteDeleteUser, CanExecuteDeleteUser);
        }

        public ICommand AddUser { get; set; }
        private void ExecuteAddUser(object obj)
        {
            _currentDialogWindow.IsVisibleChanged += (s, ev) =>
            {
                if (_currentDialogWindow.IsVisible == false && _currentDialogWindow.IsLoaded)
                    _currentDialogWindow.Close();
            };

            _currentDialogWindow.ShowDialog();

            UsersList = dbRepository.Users.GetList();
        }
        private bool CanExecuteAddUser(object obj)
        {
            if(userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).accessLevels.name != "Admin")
                return false;

            return true;
        }

        public ICommand UpdateUser { get; set; }
        private void ExecuteUpdateUser(object obj)
        {
            ((UserUpdateViewModel)(_currentDialogWindow.DataContext)).User = SelectedUser;

            _currentDialogWindow.IsVisibleChanged += (s1, ev1) =>
            {
                if (_currentDialogWindow.IsVisible == false && _currentDialogWindow.IsLoaded)
                {
                    _currentDialogWindow.Close();
                }

            };

            _currentDialogWindow.ShowDialog();

            dbRepository.Users.UpdateItem(((UserUpdateViewModel)(_currentDialogWindow.DataContext)).User);
            UsersList = dbRepository.Users.GetList();
        }
        private bool CanExecuteUpdateUser(object obj)
        {
            if (userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).accessLevels.name != "Admin")
                return false;

            return true;
        }
        
        public ICommand DeleteUser { get; set; }
        private void ExecuteDeleteUser(object obj)
        {
            dbRepository.Users.DeleteItem(SelectedUser.id);

            UsersList = dbRepository.Users.GetList();
        }
        private bool CanExecuteDeleteUser(object obj)
        {
            if (userService.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name).accessLevels.name != "Admin")
                return false;

            return true;
        }
    }
}
