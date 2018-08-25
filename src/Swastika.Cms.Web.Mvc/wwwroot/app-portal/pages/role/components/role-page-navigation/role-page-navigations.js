﻿
modules.component('rolePageNav', {
    templateUrl: '/app-portal/pages/role/components/role-page-navigation/role-page-navigations.html',
    controller: ['$scope', function ($scope) {
        var ctrl = this;
        ctrl.selected = null;
        ctrl.updateOrders = function (index) {
            ctrl.data.splice(index, 1);
            for (var i = 0; i < ctrl.data.length; i++) {
                ctrl.data[i].priority = i + 1;
            }
        };
    }],
    bindings: {
        prefix: '=',
        page: '=',
        callback: '&'
    }
});