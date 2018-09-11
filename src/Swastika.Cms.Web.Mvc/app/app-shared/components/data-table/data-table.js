
modules.component('swDataTable', {
    templateUrl: '/app-shared/components/data-table/data-table.html',
    controller: ['$rootScope', '$scope', '$location', function ($rootScope, $scope, $location) {
        var ctrl = this;
        ctrl.colWidth = 3;
        ctrl.init = function(){
            ctrl.colWidth = parseInt(9 / ctrl.columns.length);
            ctrl.lastColWidth = (9%ctrl.columns.length) > 0 ? 2: 1;                      
        };
        ctrl.translate = function (keyword) {
            return $rootScope.translate(keyword);
        };
        ctrl.selected = null;
        ctrl.updateOrders = function (index) {
            ctrl.data.items.splice(index, 1);
            for (var i = 0; i < ctrl.data.items.length; i++) {
                ctrl.data.items[i].priority = i + 1;
            }
        };
    }],
    bindings: {
        data: '=',
        callback: '&',
        editUrl: '=',
        columns: '='
    }
});