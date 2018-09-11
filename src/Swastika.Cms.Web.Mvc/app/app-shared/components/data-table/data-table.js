
modules.component('swDataTable', {
    templateUrl: '/app-shared/components/data-table/data-table.html',
    controller: ['$rootScope', '$scope', '$location', function ($rootScope, $scope, $location) {
        var ctrl = this;
        ctrl.translate = function (keyword) {
            return $rootScope.translate(keyword);
        };
        ctrl.updatePriority = async function (item) {
            await service.update(item);
        };
    }],
    bindings: {
        data: '=',
        callback: '&',
        editUrl: '=',
        columns: '='
    }
});