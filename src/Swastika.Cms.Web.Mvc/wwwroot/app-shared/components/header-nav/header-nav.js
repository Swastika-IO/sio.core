(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-shared/components/header-nav/headerNav.html',
        controller: ['$rootScope', 'CommonServices', 'AuthService', 'TranslatorService',
            function ($rootScope, commonServices, authService, translatorService) {
                var ctrl = this;
                ctrl.avatar = authService.authentication.avatar;
                ctrl.changeLang = function (lang, langIcon) {
                    ctrl.settings.lang = lang;
                    ctrl.settings.langIcon = langIcon;

                    commonServices.fillSettings(lang).then(function () {
                        translatorService.reset(lang).then(function () {
                            window.top.location = location.href;
                        });
                    });
                };
                ctrl.logOut = function () {
                    $rootScope.logOut();
                };
            }],
        bindings: {
            breadCrumbs: '=',
            settings: '='
        }
    });
})(window.angular);