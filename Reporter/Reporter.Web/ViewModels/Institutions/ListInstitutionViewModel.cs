using System.Collections.Generic;
using Reporter.Web.ViewModels.Reports;

namespace Reporter.Web.ViewModels.Institutions
{
    public class ListInstitutionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int OpenedReports { get; set; }

        public int ResolvedReports { get; set; }
    }
}