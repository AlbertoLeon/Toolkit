using Tokiota.Toolkit.XCutting.IoC;

namespace WebFormExample.Presenter
{
    public class PresenterRegister : IModuleRegistration
    {
        #region Public Methods and Operators

        public void Register(IBuilder builder)
        {
            builder.RegisterAsRequestScoped<IUserRepository, UserRepository>()
                .RegisterAsRequestScoped<IDefaultPresenterFactory, DefaultPresenterFactory>();
        }

        #endregion
    }
}