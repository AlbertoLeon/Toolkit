using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace WebFormExample
{
    public static class RouteConfig
    {
        #region Public Methods and Operators

        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }

        #endregion
    }
}