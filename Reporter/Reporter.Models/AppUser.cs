using System;
using System.Collections;
using System.Collections.Generic;

namespace Reporter.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel;

    public class AppUser : IdentityUser
    {
        private ICollection<Report> reports;

        public AppUser()
        {
            this.reports = new HashSet<Report>();
        }

        public string FullName { get; set; }
        public DateTime? JoinedOn { get; set; }
        public string Phone { get; set; }

        [DefaultValue(10)]
        public int Points { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
