using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel.MainWindow.Sections;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для EventsPage.xaml
    /// </summary>
    public partial class EventsPage : UserControl
    {
        public EventsPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            EventCreateWindow eventCreationWindow = new EventCreateWindow();
            ((EventsViewModel)this.DataContext)._currentDialogWindow = eventCreationWindow;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            EventUpdateWindow eventUpdateWindow = new EventUpdateWindow();
            ((EventsViewModel)this.DataContext)._currentDialogWindow = eventUpdateWindow;
        }
    }
}
