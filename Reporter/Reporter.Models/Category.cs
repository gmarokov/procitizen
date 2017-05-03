using System.Collections;
using System.Collections.Generic;

namespace Reporter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Report> reports;

        public Category()
        {
            this.reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Report> Reports
        {
            get { return this.reports; }
            set { this.reports = value; }
        }
    }
}
