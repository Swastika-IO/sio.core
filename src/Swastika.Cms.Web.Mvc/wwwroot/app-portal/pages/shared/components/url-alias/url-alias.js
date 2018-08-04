
modules.component('urlAlias', {
    templateUrl: '/app-portal/pages/shared/components/url-alias/url-alias.html',
    controller: ['$scope', function ($scope) {
        var ctrl = this;        
    }],
    bindings: {
        urlAlias: '=',
        callback: '&'
    }
});