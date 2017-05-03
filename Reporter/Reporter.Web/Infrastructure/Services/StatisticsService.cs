

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Models;
using Reporter.Web.Infrastructure.Services.Base;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Reporters;
using Reporter.Web.ViewModels.Statistics;

namespace Reporter.Web.Infrastructure.Services
{
    public class StatisticsService : BaseService, IStatisticsService
    {
        public StatisticsService(IReporterData data) : base(data)
        {
        }

        public IndexStatisticViewModel GetIndexViewModel()
        {
            var reporter = this.Data
                .Users
                .All()
                .OrderByDescending(r => r.Points)
                .FirstOrDefault()
                .FullName;

            var institution = this.Data
                .Institutions
                .All()
                .Select(i => new { i.Name, resolvedReports = i.Reports.Where(r => r.Status == ReportStatus.Resolved).Count() })
                .OrderByDescending(i => i.resolvedReports)
                .FirstOrDefault()
                .Name;

            var top10Reporters = this.Data
                .Users
                .All()
                .OrderByDescending(r => r.Points)
                .Take(10)
                .ProjectTo<ReporterViewModel>()
                .ToList();

            var top10InstitutionsFromDb = this.Data
                .Institutions
                .All()
                .Select(i => new
                    {
                        i.Name,
                        ResolvedReportsCount = i.Reports.Where(r => r.Status == ReportStatus.Resolved).Count(),
                        Reports = i.Reports.ToList()
                    })
                .OrderByDescending(i => i.ResolvedReportsCount)
                .Take(10)
                .ToList();

            var top10InstitutionsViewModel = new List<InstitutionViewModel>();

            foreach (var insitution in top10InstitutionsFromDb)
            {
                top10InstitutionsViewModel.Add(new InstitutionViewModel()
                {
                    Name = insitution.Name,
                    ResolvedReportsCount = insitution.ResolvedReportsCount,
                    ResolveRatio = ((double)insitution.Reports.Where((r => r.Status == ReportStatus.Resolved)).Count() / insitution.Reports.Count()) * 100
                });
            }

            var indexViewViewModel = new IndexStatisticViewModel()
            {
                TopReporter = reporter,
                TopInstitution = institution,
                Top10Institutions = top10InstitutionsViewModel,
                Top10Reporters = top10Reporters
            };

            return indexViewViewModel;
        }
    }
}