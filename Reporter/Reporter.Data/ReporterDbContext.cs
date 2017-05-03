using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.Models;

namespace Reporter.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ReporterDbContext : IdentityDbContext<AppUser>
    {
        public ReporterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Report> Reports { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Institution> Institutions { get; set; }

        public virtual IDbSet<File> Files { get; set; }

        public static ReporterDbContext Create()
        {
            return new ReporterDbContext();
        }
    }
}