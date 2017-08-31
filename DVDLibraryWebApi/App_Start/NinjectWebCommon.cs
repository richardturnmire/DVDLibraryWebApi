[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DVDLibraryWebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DVDLibraryWebApi.App_Start.NinjectWebCommon), "Stop")]

namespace DVDLibraryWebApi.App_Start
{
    using System;
    using System.Web;
    using System.Web.Configuration;
    using DVDLibraryWebApi.Data.Repositories;
    using DVDLibraryWebApi.Models.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

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
            string _mode = WebConfigurationManager.AppSettings["Mode"].ToLower();
            string _lmode = _mode.ToString();

            if ( _lmode == "sampledata" )
            {
                kernel.Bind<IDVDRepository>().To<Mock_Repository>().InSingletonScope();
            }
            else
                if ( _lmode == "entityframework" )
            {
                kernel.Bind<IDVDRepository>().To<EF_Repository>().InSingletonScope();
            }
            else
            {
                if ( _lmode == "ado" )
                {
                    kernel.Bind<IDVDRepository>().To<ADO_Repository>().InSingletonScope();
                }
                else
                {
                    throw new NotImplementedException($"Mode '{_mode}' is not valid or not implemented");
                }
            }
        }        
    }
}
