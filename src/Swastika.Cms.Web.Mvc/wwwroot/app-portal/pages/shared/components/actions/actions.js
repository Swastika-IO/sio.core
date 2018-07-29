
modules.component('actions', {
    templateUrl: '/app-portal/pages/shared/components/actions/actions.html',
    controller: ['$rootScope', function ($rootScope) {
        this.translator = $rootScope.translator;
    }],
    bindings: {
        previewUrl: '=',
        backUrl: '='
    }
});