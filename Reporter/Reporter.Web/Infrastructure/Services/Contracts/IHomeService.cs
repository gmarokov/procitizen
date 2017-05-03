using System.Collections.Generic;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services.Contracts
{
    public interface IHomeService
    {
        IList<ReportViewModel> GetIndexViewModel(int numberOfReports);
    }
}
