using Model.Interfaces;
using Model.Models;
using Model.Repositories;
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
        private SecureString _securePassword;
        private string _errorMessage;
        private bool _isViewVisible = true;

        DbRepository dbRepository;

        public string Username 
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString SecurePassword 
        {
            get => _securePassword;
            set
            {
                _securePassword = value;
                OnPropertyChanged(nameof(SecurePassword));
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
            this.dbRepository = new DbRepository();

            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        public ICommand LoginCommand { get; }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool dataValidation;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 4 ||
                SecurePassword == null || SecurePassword.Length < 3)
                dataValidation = false;
            else
                dataValidation = true;

            return dataValidation;
        }
        private void ExecuteLoginCommand(object obj)
        {
            ErrorMessage = "";
            bool validation = dbRepository.Users.AuthenticateUser(new NetworkCredential(Username, SecurePassword));

            if (validation)
            {
                users user = dbRepository.Users.GetItemByUsername(Username);

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
