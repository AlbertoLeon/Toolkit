using System.Collections.Generic;
using System.Web.UI;

using Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter;

using WebFormExample.Presenter;

namespace WebFormExample
{
    public partial class _Default : Page,
        IDefaultView
    {
        #region Fields

        private DefaultPresenter presenter;

        #endregion

        #region Constructors and Destructors

        public _Default()
        {
            var defaultPresenterFactory = InversionOfControl.Container.Resolve<IDefaultPresenterFactory>();
            presenter = defaultPresenterFactory.CreateDefaultPresenter(this);
        }

        #endregion

        #region Public Methods and Operators

        public void SetUserList(IEnumerable<UserInfoDto> list)
        {
            UserInfoGrid.DataSource = list;
            UserInfoGrid.DataBind();
        }

        #endregion
    }
}