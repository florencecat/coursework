using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Utilities;

namespace View 
{
    public partial class App : Application
    {
        private MainWindow mainWindow;
        private LoginWindow loginWindow;
        private StandardKernel kernel;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            //kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("EventsContext"));

            //IModelOperations modelOperations = kernel.Get<ModelOperations>();

            loginWindow = new LoginWindow();
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
