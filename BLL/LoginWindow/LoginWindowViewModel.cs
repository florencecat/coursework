using Model.Interfaces;
using Model.Models;
using Model.Repositories;
using Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.LoginWindow
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private string _username = "florencecat";
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private DbRepository dbRepository;
        private UserService userService;

        public string Username 
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
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
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
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

        public LoginWindowViewModel()
        {
            dbRepository = new DbRepository();
            userService = new UserService();

            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        public ICommand LoginCommand { get; }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool dataValidation;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 4 ||
                Password == null || Password.Length < 3 ||
                userService.GetItemByUsername(Username).accessLevels.name == "User")
            {
                Password = null;
                dataValidation = false;
            }
            else
                dataValidation = true;

            return dataValidation;
        }
        private void ExecuteLoginCommand(object obj)
        {
            ErrorMessage = "";

            //dbRepository.Users.CreatePasswordForUser(new NetworkCredential(Username, Password));

            bool validation = userService.AuthenticateUser(new NetworkCredential() { UserName = Username, Password = Password });

            if (validation)
            {
                users user = userService.GetItemByUsername(Username);

                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.nickname), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "Некорректные имя пользователя и/или пароль";
            }
        }
    }
}
