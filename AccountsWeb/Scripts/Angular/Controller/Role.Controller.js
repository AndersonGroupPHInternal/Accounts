(function () {
    'use strict';

    angular
        .module('App')
        .controller('RoleController', RoleController);

    RoleController.$inject = ['$filter', '$window','RoleService'];   //changed

    function RoleController($filter,$window, RoleService) {
        var vm = this;

        vm.UserId;
        
        vm.AssignedRoles = [];
        vm.Roles = [];
        
        vm.Initialise = Initialise;
        vm.GoToUpdatePage = GoToUpdatePage;  // added
        vm.GoToUpdateRole = UpdateRole;     //added
        vm.Delete = Delete;                 //added

        function Initialise(userId) {
            vm.UserId = userId;
            Read();
            if(vm.UserId != undefined) //added
            ReadAssignedRole();
        }

        function GoToUpdatePage(roleId) {         //added
            $window.location.href = '../Role/Update/' + roleId;         //added
        }                           //added

        function UpdateRole(role) {         //added
            role.AssignedRoles = $filter('filter')(vm.AssignedRoles, { roleId: role.RoleId })[0];   //added
        }                           //added

        function Read() {
            RoleService.Read()
                .then(function (response) {
                    vm.Roles = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function ReadAssignedRole() {
            RoleService.ReadAssignedRole(vm.UserId)
                .then(function (response) {
                    vm.AssignedRoles = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }


        function Delete(roleId) {                   //added
            RoleService.Delete(roleId)                  //added
                .then(function (response) {         //added
                    Read();                 //added
                })                          //added
                .catch(function (data, status) {       //added
                    new PNotify({           //added
                        title: status,      //added
                        text: data,             //added
                        type: 'error',              //added
                        hide: true,                 //added
                        addclass: "stack-bottomright"   //added
                    });             //added
                });                     //added
        }                   //added
    }                  
})();