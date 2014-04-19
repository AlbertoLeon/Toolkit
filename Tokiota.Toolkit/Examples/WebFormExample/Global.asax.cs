using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using Tokiota.Toolkit.XCutting.IoC;
using Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter;

using WebFormExample.Presenter;

namespace WebFormExample
{
    public class Global : HttpApplication,
        IContainerProvider
    {
        #region Static Fields

        private static IContainer container;

        #endregion

        #region Public Properties

        public IContainer Container
        {
            get { return container; }
            set { container = value; }
        }

        #endregion

        #region Methods

        private void Application_Start(object sender, EventArgs e)
        {
            Container = Bootstrap.Register(builder =>
            {
                new WebRegister().Register(builder);
                new PresenterRegister().Register(builder);
            });

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #endregion
    }
}