using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViewModel.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserAccount _currentUserAccount;
        private DbRepository dbRepository;
        public UserAccount CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainWindowViewModel()
        {
            dbRepository = new DbRepository();
            _currentUserAccount = new UserAccount();

            LoadCurrentUser();
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
    }
}
