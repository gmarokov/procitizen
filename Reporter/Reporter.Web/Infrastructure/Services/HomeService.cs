using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Reporter.Data;
using Reporter.Models;
using Reporter.Web.Infrastructure.Services.Base;
using Reporter.Web.Infrastructure.Services.Contracts;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.Infrastructure.Services
{
    public class HomeService : BaseService, IHomeService
    {
        //IMapper mapper;
        //public MapperConfiguration config;
        //public IMapper mapper;

        public HomeService(IReporterData data)
            : base(data)
        {
            //this.config = config;
            //config = new MapperConfiguration(cfg => {
            //    //cfg.AddProfile<AppProfile>();
                //cfg.CreateMap<Report, ReportViewModel>();
            //});

            //mapper = config.CreateMapper();
            //// or
            ////IMapper mapper = new Mapper(config);
            //var dest = mapper.Map<Report, ReportViewModel>(new Report());
        }

        public IList<ReportViewModel> GetIndexViewModel(int numberOfReports)
        {
            var indexViewModel = this.Data
                .Reports
                .All()
                .Take(6)
                .ProjectTo<ReportViewModel>()
                .ToList();

            return indexViewModel;
        }
    }
}