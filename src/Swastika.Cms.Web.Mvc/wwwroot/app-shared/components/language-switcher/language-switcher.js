(function (angular) {
    app.component('languageSwitcher', {
        templateUrl: '/app-shared/components/language-switcher/language-switcher.html',
        controller: ['$rootScope', 'commonServices', 'translatorService', function ($rootScope, commonServices, translatorService) {
            var ctrl = this;
            ctrl.changeLang = function (lang, langIcon) {
                ctrl.settings.lang = lang;
                ctrl.settings.langIcon = langIcon;

                commonServices.setSettings(ctrl.settings).then(function () {
                    translatorService.reset(lang).then(function () {
                        window.top.location = '/'+ lang;
                    });
                });
            };
            ctrl.logOut = function () {
                $rootScope.logOut();
            }
        }],
        bindings: {
            settings: '=',
            style: '=',
        }
    });
})(window.angular);