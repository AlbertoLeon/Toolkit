namespace WebFormExample.Presenter
{
    public class DefaultPresenterFactory : IDefaultPresenterFactory
    {
        #region Fields

        private readonly IUserRepository userRepository;

        #endregion

        #region Constructors and Destructors

        public DefaultPresenterFactory(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion

        #region Public Methods and Operators

        public DefaultPresenter CreateDefaultPresenter(IDefaultView view)
        {
            return new DefaultPresenter(view, userRepository);
        }

        #endregion
    }
}