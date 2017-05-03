using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporter.Web.ViewModels.Statistics;

namespace Reporter.Web.Infrastructure.Services.Contracts
{
    public interface IStatisticsService
    {
        IndexStatisticViewModel GetIndexViewModel();
    }
}
