using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reporter.Models;

namespace Reporter.Web.ViewModels.Reports
{
    public class ListReportViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ReportType Type { get; set; }

        public ReportStatus Status { get; set; }

        public string Description { get; set; }

        public string ReporterName { get; set; }

        public string CategoryName { get; set; }

        public int SupportsCount { get; set; }

        public int ViewsCount { get; set; }

        public int FilesCount { get; set; }
    }
}