namespace WebFormExample.Presenter
{
    public class DefaultPresenter
    {
        #region Fields

        private readonly IUserRepository userRepository;

        private readonly IDefaultView view;

        #endregion

        #region Constructors and Destructors

        public DefaultPresenter(IDefaultView view, IUserRepository userRepository)
        {
            this.view = view;
            this.userRepository = userRepository;

            AttachEvents();
        }

        #endregion

        #region Public Methods and Operators

        public void OnLoad()
        {
            view.SetUserList(userRepository.GetUserList());
        }

        #endregion

        #region Methods

        private void AttachEvents()
        {
            view.Load += (sender, args) => OnLoad();
        }

        #endregion
    }
}