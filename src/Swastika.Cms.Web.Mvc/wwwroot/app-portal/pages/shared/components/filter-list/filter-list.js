
modules.component('filterList', {
    templateUrl: '/app-portal/pages/shared/components/filter-list/filter-list.html',
    controller: function ($scope, $rootScope) {
        var ctrl = this;
        ctrl.orders = $rootScope.orders;
        ctrl.directions = $rootScope.directions;
        ctrl.pageSizes = $rootScope.pageSizes;
        ctrl.statuses = $rootScope.swStatus;
    },
    bindings: {
        request: '=',
        callback: '&',
    }
});