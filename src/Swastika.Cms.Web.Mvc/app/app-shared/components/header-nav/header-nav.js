(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-shared/components/header-nav/headerNav.html',
        controller: ['$rootScope', 'CommonServices', 'AuthService', 'TranslatorService', 'SiteConfigurationService',
            function ($rootScope, commonServices, authService, translatorService, siteConfigurationService) {
                var ctrl = this;
                ctrl.avatar = authService.authentication.avatar;
                ctrl.translate = $rootScope.translate;
                ctrl.getConfiguration = $rootScope.getConfiguration;
                ctrl.changeLang = function (lang, langIcon) {
                    ctrl.settings.lang = lang;
                    ctrl.settings.langIcon = langIcon;

                    commonServices.fillSettings(lang).then(function () {
                        translatorService.reset(lang).then(function () {
                            siteConfigurationService.reset(lang).then(function () {
                                window.top.location = location.href;
                            });
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