using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Web.Infrastructure.Services.Base;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Reporters;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services
{
    public class InstitutionsService : BaseService, IInstitutionsService
    {
        public InstitutionsService(IReporterData data) 
            : base(data)
        {
        }

        public IList<ListInstitutionViewModel> GetListInstitutionViewModels()
        {
            var institutionsViewModels = this.Data
                .Institutions
                .All()
                .ProjectTo<ListInstitutionViewModel>()
                .ToList();

            return institutionsViewModels;
        }
    }
}