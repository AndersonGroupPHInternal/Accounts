﻿using AccountsModel;
using System.Collections.Generic;


namespace AccountsFunction
{
    public interface IFRole
    {
        #region Create
        Role Create(int createdBy, Role role);
        #endregion

        #region Read
        List<Role> Read(string sortBy);
        List<Role> Read(int roleId, string sortBy);
        #endregion

        #region Update
        Role Update(int createdBy, Role role);
        #endregion

        #region Delete
        void Delete(int roleId);
        #endregion

        #region Other Function

        #endregion
    }
}
