using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reporter.Models
{
    public class Institution
    {
        private ICollection<Report> reports;

        public Institution()
        {
            this.reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Report> Reports
        {
            get { return this.reports; }
            set { this.reports = value; }
        }
    }
}
