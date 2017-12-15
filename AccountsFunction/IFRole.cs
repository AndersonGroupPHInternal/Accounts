using AccountsModel;
using System.Collections.Generic;


namespace AccountsFunction
{
    public interface IFRole
    {
        #region Create
        Role Create(int createdBy, Role role); //added
        #endregion

        #region Read
        Role Read(int roleId);              //added
        List<Role> Read(string sortBy);
        List<Role> Read(int userId, string sortBy);
        #endregion

        #region Update
        Role Update(int updatedBy, Role role);  //added
        #endregion

        #region Delete
        void Delete(int roleId);  //added
        #endregion

        #region Other Function

        #endregion
    }
}
