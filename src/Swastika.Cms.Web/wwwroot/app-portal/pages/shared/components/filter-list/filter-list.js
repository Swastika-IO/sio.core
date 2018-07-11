
modules.component('filterList', {
    templateUrl: '/app-portal/pages/shared/components/filter-list/filter-list.html',
    controller: function ($scope, $rootScope) {
        var ctrl = this;
        ctrl.dateRange = {
            fromDate: null,
            toDate: null
        };
        ctrl.orders = $rootScope.orders;
        ctrl.directions = $rootScope.directions;
        ctrl.pageSizes = $rootScope.pageSizes;
        ctrl.statuses = $rootScope.swStatus;
        ctrl.updateDate = function () {
            if (Date.parse(ctrl.dateRange.fromDate)) {
                ctrl.request.fromDate = new Date(ctrl.dateRange.fromDate).toISOString();
            }
            else {
                $scope.request.fromDate = null;
            }
            if (Date.parse(ctrl.dateRange.toDate)) {
                ctrl.request.toDate = new Date(ctrl.dateRange.toDate).toISOString();
            }
            else {
                ctrl.request.toDate = null;
            }
            ctrl.callback({ pageIndex: 0 })
        }
    },
    bindings: {
        request: '=',
        callback: '&',
    }
});