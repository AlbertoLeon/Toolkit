using Tokiota.Toolkit.XCutting.IoC;

using WebFormExample.Presenter;

namespace WebFormExample
{
    public class WebRegister : IModuleRegistration
    {
        #region Public Methods and Operators

        public void Register(IBuilder builder)
        {
            builder.RegisterAsRequestScoped<IDefaultView, _Default>();
        }

        #endregion
    }
}