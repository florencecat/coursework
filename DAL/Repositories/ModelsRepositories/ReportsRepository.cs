using Model.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories.ModelsRepositories
{
    internal class ReportsRepository : IReportRepository
    {
        EventsContext eventsContext;

        public ReportsRepository(EventsContext eventsContext)
        {
            this.eventsContext = eventsContext;
        }

        public List<ReportData> ParticipationsReport()
        {
            return default;
        }
    }
}
