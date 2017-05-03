using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reporter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        private ICollection<File> files;

        public Report()
        {
            this.files = new HashSet<File>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DefaultValue(ReportType.Complain)]
        public ReportType Type { get; set; }

        [Required]
        public ReportStatus Status { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public int SupportsCount { get; set; }

        public int ViewsCount { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public string ReporterId { get; set; }

        public virtual AppUser Reporter { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? InstitutionId { get; set; }

        public virtual Institution Institution { get; set; }

        public virtual ICollection<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }
    }
}
