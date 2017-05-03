using System;
using Reporter.Models;

namespace Reporter.Web.Areas.Administration.ViewModels.Reports
{
    public class AdminListReportViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ReportType Type { get; set; }

        public ReportStatus Status { get; set; }

        public string Description { get; set; }

        public string ReporterName { get; set; }

        public string CategoryName { get; set; }

        public int FilesCount { get; set; }
    }
}