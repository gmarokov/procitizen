using System.Collections.Generic;
using System.Web;
using Reporter.Web.Areas.Administration.ViewModels.Reports;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services.Contracts
{
    public interface IReportsService
    {
        IList<ListReportViewModel> GetListReportViewModels();
        IList<EditReportViewModel> GetAdminEditReportViewModels();
        IList<AdminListReportViewModel> GetAdminListReportViewModels();
        bool IsContentTypeValid(IList<HttpPostedFileBase> reportFilesForReport);
    }
}
