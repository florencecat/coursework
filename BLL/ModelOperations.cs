using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ModelOperations : IModelOperations
    {
        private IDbRepository repository;

        public IDbRepository Repository
        {
            get => this.repository;
        }

        public ModelOperations(IDbRepository repository)
        {
            this.repository = repository;
        }
    }
}
