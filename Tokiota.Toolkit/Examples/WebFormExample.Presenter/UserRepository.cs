using System.Collections.Generic;

namespace WebFormExample.Presenter
{
    public class UserRepository : IUserRepository
    {
        #region Public Methods and Operators

        public IEnumerable<UserInfoDto> GetUserList()
        {
            return new List<UserInfoDto>
                   {
                       new UserInfoDto
                       {
                           Lastname = "Mazzini",
                           Name = "Daniel",
                           Phone = "654321987"
                       },
                       new UserInfoDto
                       {
                           Lastname = "Bacardit",
                           Name = "Joan",
                           Phone = "612345678"
                       }
                   };
        }

        #endregion
    }
}