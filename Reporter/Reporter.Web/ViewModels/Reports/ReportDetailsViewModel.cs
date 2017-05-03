using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Reporter.Models;

namespace Reporter.Web.ViewModels.Reports
{
    public class ReportDetailsViewModel
    {
        //TODO To base class
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? CreatedOn {get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public ReportType Type { get; set; }

        public ReportStatus Status { get; set; }

        public string Description { get; set; }

        public string ReporterName { get; set; }

        public string CategoryName { get; set; }

        public string InstitutionName { get; set; }

        public int SupportsCount { get; set; }

        public int ViewsCount { get; set; }

        public ICollection<File> Files { get; set; }
    }
}