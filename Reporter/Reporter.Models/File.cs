using System;
using System.ComponentModel.DataAnnotations;

namespace Reporter.Models
{
    public class File
    {
        private DateTime? _createdDate;

        [Key]
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public Guid? ReportId { get; set; }

        public Report Report { get; set; }

        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }
    }
}
