using GroceryListAppWebApi.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace GroceryListAppWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            this.DependencyInjectionSetup();
        }

        /// <summary>
        /// Configure the dependency injection, creating the container, 
        /// configuring it with request life style and veryfing the container integrity.
        /// </summary>
        private void DependencyInjectionSetup()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            DependenciesRegistration.RegisterDependencies(container);

            // Register controllers
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
        }
    }
}
