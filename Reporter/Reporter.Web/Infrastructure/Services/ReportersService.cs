using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Web.Infrastructure.Services.Base;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Reporters;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services
{
    public class ReportersService : BaseService, IReportersService
    {
        public ReportersService(IReporterData data) 
            : base(data)
        {
        }

        public IList<ListReporterViewModel> GetListReporterViewModels()
        {
            var reporterViewModels = this.Data
                .Users
                .All()
                .ProjectTo<ListReporterViewModel>()
                .ToList();

            return reporterViewModels;
        }
    }
}