using System.Web;

namespace Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter
{
    public static class InversionOfControl
    {
        #region Public Properties

        public static IContainer Container
        {
            get
            {
                var containerAccessor = HttpContext.Current.ApplicationInstance as IContainerProvider;
                return containerAccessor.Container;
            }
        }

        #endregion
    }
}