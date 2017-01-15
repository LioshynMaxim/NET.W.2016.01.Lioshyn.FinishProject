using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;


namespace MvcPL.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        /// <summary>
        /// .ctor 
        /// </summary>
        /// <param name="kernel">Kernel from Ninject.</param>

        public NinjectDependencyResolver(IKernel kernel)  
        {
            this.kernel = kernel;
            kernel.ConfigurateResolverWeb();
        }

        /// <summary>
        /// Get service from Ninject.
        /// </summary>
        /// <param name="serviceType">Type of service.</param>
        /// <returns>Instance of the specified serviced.</returns>

        public object GetService(Type serviceType) => kernel.TryGet(serviceType);

        /// <summary>
        /// Get some service from Ninject.
        /// </summary>
        /// <param name="serviceType">Type of service.</param>
        /// <returns>Instance of the specified serviced.</returns>

        public IEnumerable<object> GetServices(Type serviceType) => kernel.GetAll(serviceType);
        
    }
}