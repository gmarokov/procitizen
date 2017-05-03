namespace Reporter.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class ReporterData : IReporterData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ReporterData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<AppUser> Users => this.GetRepository<AppUser>();
        public IRepository<Report> Reports => this.GetRepository<Report>();
        public IRepository<Institution> Institutions => this.GetRepository<Institution>();
        public IRepository<File> Files => this.GetRepository<File>();
        public IRepository<Category> Categories => this.GetRepository<Category>();

        public DbContext Context => this.context;

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
