using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporter.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public int TotalReports { get; set; }

        public int TotalReporters { get; set; }

        public int TotalInstitutions { get; set; }
    }
}