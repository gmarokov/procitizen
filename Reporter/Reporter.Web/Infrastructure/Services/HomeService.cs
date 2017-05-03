using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Models;
using Reporter.Web.Infrastructure.Services.Base;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Home;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services
{
    public class HomeService : BaseService, IHomeService
    {
        public HomeService(IReporterData data)
            : base(data)
        {
        }

        public IndexViewModel GetIndexViewModel()
        {
            var indexViewModel = new IndexViewModel()
            {
                TotalInstitutions = this.Data.Institutions.All().Count(),
                TotalReporters = this.Data.Users.All().Count(),
                TotalReports = this.Data.Reports.All().Count()
            };

            return indexViewModel;
        }
    }
}