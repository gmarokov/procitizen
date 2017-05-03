using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.ViewModels.Institutions
{
    public class InstitutionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ReportViewModel> Reports { get; set; }

        public int ResolvedReportsCount { get; set; }

        public int OpenedReportsCount { get; set; }

        public double ResolveRatio { get; set; }
    }
}