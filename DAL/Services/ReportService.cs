using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Model.Services
{
    internal class ReportService
    {
        private DbRepository dbRepository;

        public ReportService()
        {
            dbRepository = new DbRepository();
        }

        public void ParticipationReport()
        {
             
        }
    }
}
