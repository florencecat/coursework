using Model.Models;
using Model.Repositories;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.MainWindow.Sections
{
    public class UserUpdateViewModel : ViewModelBase
    {
        private users _user;
        private string _password;
        private bool _passwordChanged;

        private string _errorMessage;
        private accessLevels _selectedAccessLevel;
        private bool _isViewVisible;

        private DbRepository dbRepository;
        private UserService userService;

        private List<accessLevels> _accessLevels;

        public users User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string Password 
        { 
            get
            {
                if (User != null)
                    return User.password;

                return default;
            }
            set
            {
                User.password = value;
                _passwordChanged = true;
                OnPropertyChanged(nameof(Password));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public accessLevels SelectedAccessLevel
        {
            get => _selectedAccessLevel;
            set
            {
                _selectedAccessLevel = value;
                OnPropertyChanged(nameof(SelectedAccessLevel));
            }
        }
        public List<accessLevels> AccessLevels
        {
            get => _accessLevels;
        }

        public UserUpdateViewModel()
        {
            dbRepository = new DbRepository();
            userService = new UserService();

            _accessLevels = dbRepository.AccessLevels.GetList();

            _passwordChanged = false;

            UpdateUserConfirm = new RelayCommand(OnExecuteUpdateUserConfirm);
        }

        public ICommand UpdateUserConfirm { get; set; }
        

        private void OnExecuteUpdateUserConfirm(object obj)
        {
            if (SelectedAccessLevel != null)
                User.type = dbRepository.AccessLevels.GetItem(SelectedAccessLevel.id).id;
            if (_passwordChanged == true)
                User.password = userService.CreatePasswordForUser(new System.Net.NetworkCredential(User.nickname, User.password));

            IsViewVisible = false;
        }
    }
}
