using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reporter.Common;
using Reporter.Models;

namespace Reporter.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ReporterDbContext>
    {
        private UserManager<AppUser> userManager;
        private IUserStore<AppUser> userStore;
        private IRandomGenerator random;


        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(Reporter.Data.ReporterDbContext context)
        {
            this.userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            this.SeedRoles(context);
            this.SeedInstitutions(context);
            this.SeedCategories(context);
            this.SeedUsers(context);
            this.SeedReports(context);
        }

        private void SeedCategories(ReporterDbContext context)
        {
            var categories = new List<Category>()
            {
                new Category(){ Name = "Municipal property" },
                new Category(){ Name = "Municipal enterprises" },
                new Category(){ Name = "Municipal finance" },
                new Category(){ Name = "Municipal administration" },
                new Category(){ Name = "Local taxes and fees" },
                new Category(){ Name = "Planning and development of the territory" },
                new Category(){ Name = "Education" },
                new Category(){ Name = "Health" },
                new Category(){ Name = "Acquirements" },
                new Category(){ Name = "Public works and utilities" },
                new Category(){ Name = "Social services" },
                new Category(){ Name = "Environmental protection and rational use of the natural resources" },
                new Category(){ Name = "Maintenance and safeguarding of the cultural, historic and architectural monuments" },
                new Category(){ Name = "Tourism and sport development" },
                new Category(){ Name = "Protection against natural disasters" },
                new Category(){ Name = "Administrative service" },
                new Category(){ Name = "Stray animals" },
                new Category(){ Name = "Pavement issues or pavement defects and failures" },
            };

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(c => c.Name, category);
            }

            context.SaveChanges();
        }

        private void SeedRoles(ReporterDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.ModeratorRole));
            context.SaveChanges();
        }

        private void SeedUsers(ReporterDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var regularUser = new AppUser()
            {
                Email = "user@demo.com",
                FullName = "Regular User",
                JoinedOn = DateTime.Now,
                UserName = "user@demo.com"
            };
            this.userManager.Create(regularUser, "qwerty1234");

            var moderatorUser = new AppUser()
            {
                Email = "moderator@demo.com",
                FullName = "Moderator",
                JoinedOn = DateTime.Now,
                UserName = "moderator@demo.com"
            };
            var result = this.userManager.Create(moderatorUser, "qwerty1234");
            this.userManager.AddToRole(moderatorUser.Id, GlobalConstants.ModeratorRole);

            var adminUser = new AppUser()
            {
                Email = "webmaster@demo.com",
                FullName = "Webmaster",
                JoinedOn = DateTime.Now,
                UserName = "webmaster@reporter.com"
            };
            this.userManager.Create(adminUser, "qwerty1234");
            this.userManager.AddToRole(adminUser.Id, GlobalConstants.ModeratorRole);
            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
        }

        private void SeedInstitutions(ReporterDbContext context)
        {
            var institutions = new List<Institution>()
            {
                new Institution() { Name = "Municipality of Sofia" },
                new Institution() { Name = "Municipality of Plovdiv" },
                new Institution() { Name = "Municipality of Varna" },
                new Institution() { Name = "Municipality of Burgas" },
                new Institution() { Name = "Municipality of Kardzhali" }
            };

            foreach (var institution in institutions)
            {
                context.Institutions.AddOrUpdate(i => i.Name, institution);
            }

            context.SaveChanges();
        }

        private void SeedReports(ReporterDbContext context)
        {
            //var image = this.GetSampleImage();
            var users = context.Users.Take(2).ToList();
            var institutions = context.Institutions.Take(4).ToList();
            var categories = context.Categories.Take(5).ToList();

            var reports = new List<Report>()
            {
                new Report()
                {
                    Id = Guid.NewGuid(),
                    Title = "Bad pavement section on the street",
                    Reporter = users[0],
                    ReporterId = users[0].Id,
                    Description = "This is sooooooo long test description from the seed. Please delete it after started using the app.",
                    //Image = image,
                    Status = ReportStatus.Waiting,
                    Institution = institutions[0],
                    InstitutionId = institutions[0].Id,
                    Category = categories[1],
                    CategoryId = categories[1].Id,
                    Type = ReportType.Complain,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new Report()
                {
                    Id = Guid.NewGuid(),
                    Title = "Coruption in the local administration",
                    Reporter = users[1],
                    ReporterId = users[1].Id,
                    Description = "The longestwordontheworld. Please, watch out!",
                    //Image = image,
                    Status = ReportStatus.Reported,
                    Institution = institutions[1],
                    InstitutionId = institutions[1].Id,
                    Category = categories[2],
                    CategoryId = categories[2].Id,
                    Type = ReportType.Suggestion,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
                new Report()
                {
                    Id = Guid.NewGuid(),
                    Title = "Lost dog in the park",
                    Reporter = users[1],
                    ReporterId = users[1].Id,
                    Description = "The longestwordontheworld. Please, watch out!",
                    //Image = image,
                    Status = ReportStatus.Reported,
                    Institution = institutions[2],
                    InstitutionId = institutions[2].Id,
                    Category = categories[2],
                    CategoryId = categories[2].Id,
                    Type = ReportType.Complain,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                },
            };

            foreach (var report in reports)
            {
                context.Reports.AddOrUpdate(r => r.Title, report);
            }   

            context.SaveChanges();
        }

        //private Image GetSampleImage()
        //{
        //    var directory = AssemblyHelpers.GetDirectoryForAssembly(Assembly.GetExecutingAssembly());
        //    var file = File.ReadAllBytes(directory + "/Content/Images/report-icon.gif");
        //    var image = new Image()
        //    {
        //        Content = file,
        //        FileExtension = "png"
        //    };

        //    return image;
        //}
    }
}