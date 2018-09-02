
modules.component('filterList', {
    templateUrl: '/app-shared/components/filter-list/filter-list.html',
    controller: ['$scope', '$rootScope', 'ngAppSettings', function ($scope, $rootScope, ngAppSettings) {
        var ctrl = this;
        ctrl.dateRange = {
            fromDate: null,
            toDate: null
        };
        ctrl.orders = ngAppSettings.orders;
        ctrl.directions = ngAppSettings.directions;
        ctrl.pageSizes = ngAppSettings.pageSizes;
        ctrl.statuses = ngAppSettings.swStatus;
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
            ctrl.callback({ pageIndex: 0 });
        };
    }],
    bindings: {
        request: '=',
        callback: '&'
    }
});