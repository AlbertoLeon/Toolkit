using System;

namespace Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter
{
    public static class Bootstrap
    {
        #region Public Methods and Operators

        public static IContainer Register(Action<IBuilder> buildAction)
        {
            var builder = new WindsorBuilder();
            if(buildAction != null)
                buildAction(builder);

            return builder.Build();
        }

        #endregion
    }
}