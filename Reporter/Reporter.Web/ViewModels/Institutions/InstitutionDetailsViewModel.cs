using System.Collections.Generic;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.ViewModels.Institutions
{
    public class InstitutionDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ResolvedReportsCount { get; set; }

        public int OpenedReportsCount { get; set; }

        public double ResolveRatio { get; set; }
    }
}