using AccountsData;
using AccountsEntity;
using AccountsModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FRole : IFRole
    {
        private IDRole _iDRole;

        public FRole(IDRole iDRoles)
        {
            _iDRole = iDRoles;
        }
        
        public FRole()
        {
            _iDRole = new DRole();

        }
        #region Create
        public Role Create(int createdBy, Role role)      //added
        {                                                 //added

            var eRole = ERole(role);                      //added
            eRole.CreatedDate = DateTime.Now;             //added              
            eRole.CreatedBy = createdBy;                  //added
            eRole = _iDRole.Insert(eRole);                //added
            return Role(eRole);                           //added
        }                                                 //added
        #endregion


        #region Read
        public Role Read(int roleId)                                    //added
        {                                                               //added
            var eRole = _iDRole.Read<ERole>(a => a.RoleId == roleId);   //added
            return Role(eRole);                                         //added
        }                                                               //added
        public List<Role> Read(string sortBy)
        {
            var eRoles = _iDRole.Read<ERole>(a => true, sortBy);
            return Roles(eRoles);
        }

        public List<Role> Read(int userId, string sortBy)
        {
            var eRoles = _iDRole.Read<ERole>(a => a.UserRoles.Any(b => b.User.UserId == userId), sortBy);
            return Roles(eRoles);
        }
        #endregion

        #region Update
        public Role Update(int updatedBy, Role role)                    //added
        {                                                               //added
            var eRole = ERole(role);                                    //added
            eRole.UpdatedDate = DateTime.Now;                           //added
            eRole.UpdatedBy = updatedBy;                                //added
            eRole = _iDRole.Update(eRole);                              //added
            return Role(eRole);                                         //added
        }                                                               //added
        #endregion

        #region Delete
        public void Delete(int roleId)                                     //added
        {                                                                  //added
            _iDRole.Delete<ERole>(a => a.RoleId == roleId);                //added
        }                                                                  //added
        #endregion

        #region Other Function
        private ERole ERole(Role role)                           //added
        {                                                        //added
            return new ERole                                     //added
            {                                                    //added
                CreatedDate = role.CreatedDate,                  //added
                UpdatedDate = role.UpdatedDate,                  //added
                        
                CreatedBy = role.CreatedBy,                      //added
                UpdatedBy = role.UpdatedBy,                      //added
                RoleId = role.RoleId,                            //added
                Name = role.Name                                 //added
            };                                                   //added
        }                                                        //added

        private Role Role(ERole eRole)                          //added
        {                                                       //added
            return new Role                                     //added
                {                                               //added
                CreatedDate = eRole.CreatedDate,                //added
                UpdatedDate = eRole.UpdatedDate,                //added
                                                                        
                CreatedBy = eRole.CreatedBy,                    //added
                UpdatedBy = eRole.UpdatedBy,                       //added
                RoleId = eRole.RoleId,                          //added
                Name = eRole.Name                                  //added
            };                                                     //added
        }                                                       //added
        private List<Role> Roles(List<ERole> eRoles)
        {
            
            return eRoles.Select(a => new Role
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                RoleId = a.RoleId,
                UpdatedBy = a.UpdatedBy,

                Name = a.Name
            }).ToList();
        }
        #endregion

    }
}
