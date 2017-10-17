using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Reporter.Models;
using System.ComponentModel.DataAnnotations;

namespace Reporter.Web.ViewModels.Reports
{
    public class CreateReportViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public ReportType? Type { get; set; }

        public ReportStatus Status { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string ReporterId { get; set; }

        public AppUser Reporter { get; set; }

        public IEnumerable<SelectListItem> Institutions { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Institution")]
        public int SelectedInstitutionId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Category")]
        public int SelectedCategoryId { set; get; }

        public IList<HttpPostedFileBase> FilesForReport { get; set; }
    }
}