using Reporter.Models;
using Reporter.Web.Areas.Administration.ViewModels.Reports;
using Reporter.Web.ViewModels;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Reporters;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                //Reports
                cfg.CreateMap<Report, ReportViewModel>().ReverseMap();
                cfg.CreateMap<CreateReportViewModel, Report>()
                    .ForMember(c => c.CategoryId, opt => opt.MapFrom(src => src.SelectedCategoryId))
                    .ForMember(i => i.InstitutionId, opt => opt.MapFrom(src => src.SelectedInstitutionId));
                cfg.CreateMap<Report, ListReportViewModel>()
                    .ForMember(r => r.ReporterName, opt => opt.MapFrom(rn => rn.Reporter.FullName))
                    .ForMember(dest => dest.FilesCount, opt => opt.MapFrom(src => src.Files.Count));
                cfg.CreateMap<Report, ReportDetailsViewModel>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                    .ForMember(dest => dest.ReporterName, opt => opt.MapFrom(src => src.Reporter.FullName))
                    .ForMember(dest => dest.InstitutionName, opt => opt.MapFrom(src => src.Institution.Name))
                    .ReverseMap();

                //Reports Admin
                cfg.CreateMap<Report, EditReportViewModel>()
                    .ForMember(dest => dest.SelectedCategoryId, opt => opt.MapFrom(src => src.Category.Id))
                    .ForMember(dest => dest.ReporterId, opt => opt.MapFrom(src => src.Reporter.Id));

                cfg.CreateMap<Report, AdminListReportViewModel>()
                    .ForMember(r => r.ReporterName, opt => opt.MapFrom(rn => rn.Reporter.FullName))
                    .ForMember(dest => dest.FilesCount, opt => opt.MapFrom(src => src.Files.Count));
                /*.ForMember(dest => dest.SelectedInstitutionId, opt => opt.MapFrom(src => src.Institution.Id))*/

                cfg.CreateMap<EditReportViewModel, Report>()
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SelectedCategoryId))
                    /*.ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.SelectedInstitutionId))*/;

                //Reporters
                cfg.CreateMap<AppUser, ListReporterViewModel>()
                    .ForMember(dest => dest.NumberOfReports, opt => opt.MapFrom(src => src.Reports.Count))
                    .ReverseMap();
                cfg.CreateMap<AppUser, ReporterDetailsViewModel>();
                cfg.CreateMap<AppUser, ReporterViewModel>();

                //Institutions
                cfg.CreateMap<Institution, ListInstitutionViewModel>()
                    .ForMember(dest => dest.OpenedReports, opt => opt.MapFrom(src => src.Reports.Count))
                    .ForMember(dest => dest.ResolvedReports, opt => opt.MapFrom(src => (src.Reports.Where(r => r.Status == ReportStatus.Resolved)).Count()));
                cfg.CreateMap<Institution, InstitutionDetailsViewModel>()
                    .ForMember(dest => dest.ResolvedReportsCount, opt => opt.MapFrom(src => (src.Reports.Where(r => r.Status == ReportStatus.Resolved)).Count()))
                    .ForMember(dest => dest.OpenedReportsCount, opt => opt.MapFrom(src => src.Reports.Count))
                    .ForMember(dest => dest.ResolveRatio, opt => 
                        opt.MapFrom(src => 
                            ((double)src.Reports.Where((r => r.Status == ReportStatus.Resolved)).Count() / src.Reports.Count()) * 100  
                        ));
            });
        }
    }
}