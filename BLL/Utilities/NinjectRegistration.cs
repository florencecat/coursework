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
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IModelOperations>().To<ModelOperations>();
        }
    }
}
