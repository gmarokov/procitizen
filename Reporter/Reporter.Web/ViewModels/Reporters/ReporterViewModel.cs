using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reporter.Models;

namespace Reporter.Web.ViewModels.Reporters
{
    public class ReporterViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public DateTime? JoinedOn { get; set; }

        public List<Report> Reports { get; set; }

        public int Points { get; set; }
    }
}