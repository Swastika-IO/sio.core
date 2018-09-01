modules.component('mainSideBarDynamic', {
    templateUrl: '/app-shared/components/main-side-bar-dynamic/main-side-bar-dynamic.html',
    controller: ['$rootScope', '$scope', 'RoleServices', 'translatorService', function ($rootScope, $scope, roleServices, translatorService) {
        var ctrl = this;
        ctrl.init = function () {
            if (ctrl.roles) {
                ctrl.role = ctrl.roles[0];
                console.log(ctrl.role);
            }    
        };
    }],
    bindings: {
        roles: '=',
        activedRole: '=',
        translate: '&'
    }
});