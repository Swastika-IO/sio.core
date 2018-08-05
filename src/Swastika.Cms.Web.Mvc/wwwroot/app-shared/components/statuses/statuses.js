
modules.component('statuses', {
    templateUrl: '/app-portal/pages/shared/components/statuses/statuses.html',
    controller: ['$rootScope', function ($rootScope) {
        this.swStatus = $rootScope.swStatus;
    }],
    bindings: {
        status: '=',
    }
});