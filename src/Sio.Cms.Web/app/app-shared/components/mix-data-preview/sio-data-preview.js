modules.component('sioDataPreview', {
    templateUrl: '/app/app-shared/components/sio-data-preview/sio-data-preview.html',
    controller: ['$rootScope', function ($rootScope) {
        var ctrl = this;
    }
    ],
    bindings: {
        type: '=',
        value: '=',
        width: '=',
    }
});
