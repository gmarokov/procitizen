namespace Reporter.Data
{
    using System.Data.Entity;
    using Reporter.Models;

    public interface IReporterData
    {
        DbContext Context { get; }

        IRepository<AppUser> Users { get; }

        IRepository<Report> Reports { get; }

        IRepository<Institution> Institutions { get; }

        IRepository<Category> Categories { get; }

        IRepository<File> Files { get; }

        void Dispose();

        int SaveChanges();
    }
}
