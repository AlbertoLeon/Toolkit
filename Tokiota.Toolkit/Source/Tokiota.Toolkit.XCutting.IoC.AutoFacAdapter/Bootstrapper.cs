using System;

namespace Tokiota.Toolkit.XCutting.IoC.AutofacAdapter
{
    /// <summary>
    /// Call for boostrapp
    /// <example>
    ///     IContainer container = Bootstrapper.Register(bdr =>
    ///        {
    ///            new Library1ModuleRegistration().Register(bdr);
    ///            new Library2ModuleRegistration().Register(bdr);
    ///        });
    /// </example>
    /// </summary>
    public static class Bootstrapper
    {
        #region Public Methods and Operators

        public static IContainer Register(Action<IBuilder> setupAction = null)
        {
            var builder = new AutofacBuilder();

            if(setupAction != null)
                setupAction(builder);

            return builder.Build();
        }

        #endregion
    }
}