using Model.Interfaces;
using Model.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Utilities
{
    public class ServiceModule : NinjectModule
    {
        string connectionString;

        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IDbRepository>().To<DbRepository>().InSingletonScope().WithConstructorArgument(this.connectionString);
        }
    }
}
