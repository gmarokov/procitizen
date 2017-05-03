using System.Collections.Generic;
using Reporter.Web.ViewModels.Institutions;
using Reporter.Web.ViewModels.Reporters;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.ViewModels.Statistics
{
    public class IndexStatisticViewModel
    {
        public string TopReporter { get; set; }

        public string TopInstitution { get; set; }

        public IList<InstitutionViewModel> Top10Institutions { get; set; }

        public IList<ReporterViewModel> Top10Reporters { get; set; }
    }
}