namespace WebFormExample.Presenter
{
    public interface IDefaultPresenterFactory
    {
        #region Public Methods and Operators

        DefaultPresenter CreateDefaultPresenter(IDefaultView view);

        #endregion
    }
}