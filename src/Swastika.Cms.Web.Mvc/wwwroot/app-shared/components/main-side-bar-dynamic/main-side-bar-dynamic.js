modules.component('mainSideBarDynamic', {
    templateUrl: '/app-shared/components/main-side-bar-dynamic/main-side-bar-dynamic.html',
    controller: ['$rootScope', '$scope', 'RoleServices', 'translatorService', function ($rootScope, $scope, roleServices, translatorService) {
        var ctrl = this;
        ctrl.role = null;
        ctrl.init = async function () {
            var getPermissions = await roleServices.getPermissions();
            if (getPermissions.isSucceed) {
                ctrl.items = getPermissions.data;
                ctrl.role = ctrl.items[0];
            }
            console.log(ctrl.role);
            $scope.$apply();
        };        
    }],
    bindings: {        
        translate: '&'
    }
});