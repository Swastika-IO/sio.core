
app.component('moduleMain', {
    templateUrl: '/app-portal/pages/module/components/main/main.html',
    controller: ['$rootScope', function ($rootScope) {
        this.settings = $rootScope.settings;
    }],
    bindings: {
        module: '=',
    }
});