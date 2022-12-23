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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : UserControl
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            UserCreateWindow userCreationWindow = new UserCreateWindow();
            ((UsersViewModel)this.DataContext)._currentDialogWindow = userCreationWindow;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UserUpdateWindow userUpdateWindow = new UserUpdateWindow();
            ((UsersViewModel)this.DataContext)._currentDialogWindow = userUpdateWindow;
        }
    }
}
