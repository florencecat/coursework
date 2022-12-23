using Model.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.MainWindow.Sections
{
    public class EventUpdateViewModel : ViewModelBase
    {
        private events _event;
        private string _errorMessage;
        private categories _selectedCategory;
        private bool _isViewVisible = true;

        private DbRepository dbRepository;

        private List<categories> categories;

        public events Event
        {
            get => _event;
            set
            {
                _event = value;
                OnPropertyChanged(nameof(Event));
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
        public categories SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        public List<categories> Categories
        {
            get => categories;
        }

        public EventUpdateViewModel()
        {
            dbRepository = new DbRepository();

            categories = dbRepository.Categories.GetList();

            UpdateEventConfirm = new RelayCommand(OnExecuteUpdateEventConfirm);
        }

        public ICommand UpdateEventConfirm { get; set; }
        private void OnExecuteUpdateEventConfirm(object obj)
        {
            Event.category = dbRepository.Categories.GetItem(SelectedCategory.id).id;
            IsViewVisible = false;
        }
    }
}
