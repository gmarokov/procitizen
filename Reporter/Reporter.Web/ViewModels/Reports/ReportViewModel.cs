using System;
using Reporter.Models;

namespace Reporter.Web.ViewModels.Reports
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }

        public ReportType Type { get; set; }

        public ReportStatus Status { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string ReporterName { get; set; }
    }
}