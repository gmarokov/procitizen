using Reporter.Web.Infrastructure.Caching;
using Reporter.Web.Infrastructure.Populators;
using Reporter.Web.Infrastructure.Services;
using Reporter.Web.Infrastructure.Services.Contracts;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Reporter.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Reporter.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Reporter.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using Reporter.Data;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using AutoMapper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Context
            kernel.Bind<DbContext>().To<ReporterDbContext>();
            kernel.Bind<IReporterData>().To<ReporterData>();

            // Services
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<IReportsService>().To<ReportsService>();
            kernel.Bind<IReportersService>().To<ReportersService>();
            kernel.Bind<IInstitutionsService>().To<InstitutionsService>();
            kernel.Bind<IStatisticsService>().To<StatisticsService>();

            kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();

            kernel.Bind<ICacheService>().To<InMemoryCache>();
            //kernel.Bind<MapperConfiguration>().To<MapperConfiguration>();
        }        
    }
}
