using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Reporter.Models;
namespace Reporter.Web.ViewModels.Reports
{
    public class CreateReportViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ReportType? Type { get; set; }

        public ReportStatus Status { get; set; }

        public string Description { get; set; }

        public string ReporterId { get; set; }

        public AppUser Reporter { get; set; }

        public IEnumerable<SelectListItem> Institutions { get; set; }

        public int SelectedInstitutionId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public int SelectedCategoryId { set; get; }

        public IList<HttpPostedFileBase> FilesForReport { get; set; }
    }
}