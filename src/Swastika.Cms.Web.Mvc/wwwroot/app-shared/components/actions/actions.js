
modules.component('actions', {
    templateUrl: '/app-shared/components/actions/actions.html',
    controller: ['$rootScope', 'translatorService', function ($rootScope, translatorService) {
        this.translator = translatorService;
    }],
    bindings: {
        previewUrl: '=',
        backUrl: '='
    }
});