using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Registrator
    {
        private MainWindow mainWindow;
        private LoginWindow loginWindow;

        public Registrator()
        {
            loginWindow = new LoginWindow();
            mainWindow = new MainWindow();

            loginWindow.Show();

            loginWindow.IsVisibleChanged += (s, ev) =>
            {
                if (loginWindow.IsVisible == false && loginWindow.IsLoaded)
                {
                    mainWindow = new MainWindow();

                    mainWindow.Show();
                    loginWindow.Close();
                }
            };

            
        }

        
    }
}
