using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;
using ViewModel.LoginWindow;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void mainBorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
        private void minimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void closeButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((LoginWindowViewModel)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
        }
    }
}
