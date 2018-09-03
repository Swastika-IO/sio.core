
modules.component('actions', {
    templateUrl: '/app-shared/components/actions/actions.html',
    controller: ['$rootScope', '$scope', '$location', function ($rootScope, $scope, $location) {
        var ctrl = this;
        ctrl.translate = function (keyword) {
            return $rootScope.translate(keyword);
        };
        ctrl.back = function () {
            $location.path(document.referrer);
            $scope.$apply();
        };
    }],
    bindings: {
        previewUrl: '=',
        backUrl: '='
    }
});