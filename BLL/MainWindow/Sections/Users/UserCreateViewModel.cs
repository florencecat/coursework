using Model.Models;
using Model.Repositories;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.MainWindow.Sections
{
    public class UserCreateViewModel : ViewModelBase
    {

        private string _name;
        private string _surname;
        private string _email;
        private string _nickname;
        private string _password;
        private DateTime _date;
        private accessLevels _accessLevel;
       
        private string _errorMessage;
        private bool _isViewVisible;

        private DbRepository dbRepository;
        private UserService userService;

        public List<accessLevels> AccessLevels { get; set; }
        
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

        public string Name
        { 
            get => _name; 
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Nickname
        {
            get => _nickname;
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public accessLevels AccessLevel
        {
            get => _accessLevel;
            set
            {
                _accessLevel = value;
                OnPropertyChanged(nameof(AccessLevel));
            }
        }

        public UserCreateViewModel()
        {
            dbRepository = new DbRepository();
            userService = new UserService();

            AccessLevels = dbRepository.AccessLevels.GetList();

            AddUserConfirm = new RelayCommand(OnExecuteAddUserConfirm, CanExecuteAddUserConfirm);
            AddUserCancel = new RelayCommand(OnExecuteAddUserCancel);
        }

        public ICommand AddUserCancel { get; set; }
        private void OnExecuteAddUserCancel(object obj)
        {
            IsViewVisible = false;
        }

        public ICommand AddUserConfirm { get; set; }
        private void OnExecuteAddUserConfirm(object obj)
        {
            users user = new users()
            {
                id = Guid.NewGuid(),
                name = Name,
                surname = Surname,
                birthdate = Date,
                email = Email,
                nickname = Nickname,
                type = AccessLevel.id,
                salt = "1",
                password = userService.HashPassword(Password),
            };

            dbRepository.Users.CreateItem(user);

            IsViewVisible = false;
        }
        private bool CanExecuteAddUserConfirm(object obj)
        {
            if (Name == null || Surname == null || Email == null || Nickname == null || AccessLevel == null || Password == null)
                return false;

            return true;
        }
    }
}