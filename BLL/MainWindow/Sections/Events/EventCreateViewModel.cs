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
    public class EventCreateViewModel : ViewModelBase
    {
        private string _name;
        private categories _category;
        private DateTime _date;
        private string _description;
        private int _cost;
        private string _errorMessage;

        private bool _isViewVisible;

        private DbRepository dbRepository;
        private EventService eventService;

        private List<categories> categories;

        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public categories Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
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
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public int Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged(nameof(Cost));
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


        public List<categories> Categories 
        { 
            get => categories; 
        }

        public EventCreateViewModel()
        {
            dbRepository = new DbRepository();
            eventService = new EventService();

            categories = dbRepository.Categories.GetList();

            AddEventConfirm = new RelayCommand(OnExecuteAddEventConfirm, CanExecuteAddEventConfirm);
            AddEventCancel = new RelayCommand(OnExecuteAddEventCancel);
        }

        public ICommand AddEventCancel { get; set; }
        private void OnExecuteAddEventCancel(object obj)
        {
            IsViewVisible = false;
        }

        public ICommand AddEventConfirm { get; set; }
        private void OnExecuteAddEventConfirm(object obj)
        {
            events @event = new events()
            {
                id = Guid.NewGuid(),
                name = Name,
                description = Description,
                date = Date,
                category = Category.id,
                cost = Cost
            };

            eventService.CreateEvent(@event);

            IsViewVisible = false;
        }
        private bool CanExecuteAddEventConfirm(object obj)
        {
            if (Name == null || Date == null || Category == null || Description == null)
            {
                ErrorMessage = "Все поля, кроме Описание и Цена, должны быть заполнены.";
                return false;
            }

            return true;
        }

        
    }
}
