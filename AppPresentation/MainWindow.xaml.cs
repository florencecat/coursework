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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMaximized = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void mainBorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
        private void maximizeButtonClick(object sender, RoutedEventArgs e)
        {
            switch (IsMaximized)
            {
                case true:
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                    break;

                case false:
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                    break;
            }
        }
        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

