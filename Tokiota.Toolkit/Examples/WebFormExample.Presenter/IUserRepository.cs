using System.Collections.Generic;

namespace WebFormExample.Presenter
{
    public interface IUserRepository
    {
        #region Public Methods and Operators

        IEnumerable<UserInfoDto> GetUserList();

        #endregion
    }
}