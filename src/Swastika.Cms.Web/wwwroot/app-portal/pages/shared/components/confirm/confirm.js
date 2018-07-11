modules.component('confirm', {
    templateUrl: '/app-portal/pages/shared/components/confirm/confirm.html',
    controller: ['$rootScope', '$scope', function ($rootScope, $scope) {
        var ctrl = this;
        ctrl.executeFunctionByName =async function (functionName, args, context) {
            var result = await $rootScope.executeFunctionByName(functionName, args, context);
            if (result) {
                $scope.$apply();
            }
        }
    }],
    bindings: {
        message: '='
    }
});