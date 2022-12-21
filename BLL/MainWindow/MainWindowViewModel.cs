using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.MainWindow.Sections;

namespace ViewModel.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserAccount _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private string _icon;

        private DbRepository dbRepository;
        private string _errorMessage;
        private bool _isViewVisible = true;

        //Properties
        public UserAccount CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
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
        public ViewModelBase CurrentChildView 
        { 
            get => _currentChildView; 
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }


        //Methods
        public MainWindowViewModel()
        {
            dbRepository = new DbRepository();
            _currentUserAccount = new UserAccount();

            LogoutCommand = new RelayCommand(ExecuteLoginCommand);
            ShowHomeViewCommand = new RelayCommand(ExecuteShowHomeViewCommand);
            ShowEventsViewCommand = new RelayCommand(ExecuteShowEventsViewCommand);
            ShowUsersViewCommand = new RelayCommand(ExecuteShowUsersViewCommand);
            ShowOrganizationsViewCommand = new RelayCommand(ExecuteShowOrganizationsViewCommand);

            ExecuteShowHomeViewCommand(null);

            LoadCurrentUser();
        }

        private void ExecuteShowOrganizationsViewCommand(object obj)
        {
            CurrentChildView = new OrganizationsViewModel();
            Caption = "Организации";
            Icon = "AccountGroup";
        }

        private void ExecuteShowUsersViewCommand(object obj)
        {
            CurrentChildView = new UsersViewModel();
            Caption = "Пользователи";
            Icon = "AccountMultiple";
        }

        private void ExecuteShowEventsViewCommand(object obj)
        {
            CurrentChildView = new EventsViewModel();
            Caption = "События";
            Icon = "Ticket";
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Главная страница";
            Icon = "Home";
        }

        private void LoadCurrentUser()
        {
            users user = dbRepository.Users.GetItemByUsername(Thread.CurrentPrincipal.Identity.Name);

            if (user != null)
            {
                _currentUserAccount.Name = user.name;
                _currentUserAccount.Surname = user.surname;
                _currentUserAccount.Nickname = user.nickname;
                _currentUserAccount.BirthDate = (DateTime)user.birthdate;
                _currentUserAccount.Email = user.email;
                _currentUserAccount.Type = dbRepository.AccessLevels.GetItem(user.type).name;
            }
        }

        public ICommand LogoutCommand { get; set; }
        public ICommand ShowHomeViewCommand { get; set; }
        public ICommand ShowEventsViewCommand { get; set; }
        public ICommand ShowUsersViewCommand { get; set; }
        public ICommand ShowOrganizationsViewCommand { get; set; }

        private void ExecuteLoginCommand(object obj)
        {
            Thread.CurrentPrincipal = null;
            IsViewVisible = false;
        }


    }
}
