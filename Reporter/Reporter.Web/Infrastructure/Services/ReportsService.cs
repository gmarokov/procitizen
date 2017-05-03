using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Web.Areas.Administration.ViewModels.Reports;
using Reporter.Web.Infrastructure.Services.Base;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services
{
    public class ReportsService : BaseService, IReportsService
    {
        public ReportsService(IReporterData data) : base(data)
        {
        }

        public IList<ListReportViewModel> GetListReportViewModels()
        {
            var listReportViewModels = this.Data
                .Reports
                .All()
                .ProjectTo<ListReportViewModel>()
                .ToList();

            return listReportViewModels;
        }

        public IList<EditReportViewModel> GetAdminEditReportViewModels()
        {
            var listReportViewModels = this.Data
                .Reports
                .All()
                .ProjectTo<EditReportViewModel>()
                .ToList();

            return listReportViewModels;
        }

        public IList<AdminListReportViewModel> GetAdminListReportViewModels()
        {
            var listReportViewModels = this.Data
                .Reports
                .All()
                .ProjectTo<AdminListReportViewModel>()
                .ToList();

            return listReportViewModels;
        }

        public bool IsContentTypeValid(IList<HttpPostedFileBase> reportFilesForReport)
        {
            bool isValidContentType = true;

            //foreach (var file in reportFilesForReport)
            //{
            //    if ()
            //    {
                    
            //    }
            //}

            return isValidContentType;
        }
    }
}