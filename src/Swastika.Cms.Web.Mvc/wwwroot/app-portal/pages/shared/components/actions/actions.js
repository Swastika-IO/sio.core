
modules.component('actions', {
    templateUrl: '/app-portal/pages/shared/components/actions/actions.html',
    controller: ['$rootScope', 'translator', function ($rootScope, translator) {
        this.translator = translator;
    }],
    bindings: {
        previewUrl: '=',
        backUrl: '='
    }
});