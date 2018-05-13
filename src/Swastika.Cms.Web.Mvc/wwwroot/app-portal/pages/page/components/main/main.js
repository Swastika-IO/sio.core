
app.component('pageMain', {
    templateUrl: '/app-portal/pages/page/components/main/main.html',
    controller: ['$rootScope', function ($rootScope) {
        this.settings = $rootScope.settings;
    }],
    bindings: {
        page: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});