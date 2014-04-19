using System;
using System.Collections.Generic;

namespace WebFormExample.Presenter
{
    public interface IDefaultView
    {
        #region Public Events

        event EventHandler Load;

        #endregion

        #region Public Methods and Operators

        void SetUserList(IEnumerable<UserInfoDto> list);

        #endregion
    }
}