(function (angular) {
    app.component('languageSwitcher', {
        templateUrl: '/app-shared/components/language-switcher/language-switcher.html',
        controller: ['$rootScope','$location', 'commonServices', 'translatorService', function ($rootScope,$location, commonServices, translatorService) {
            var ctrl = this;
            ctrl.changeLang = function (lang, langIcon) {
                if (ctrl.settings.lang !== lang) {
                    var oldLang = ctrl.settings.lang;
                    ctrl.settings.lang = lang;
                    ctrl.settings.langIcon = langIcon;

                    commonServices.setSettings(ctrl.settings).then(function () {
                        translatorService.reset(lang).then(function () {
                            var url = $location.$$absUrl;
                            window.top.location = url.replace(oldLang, lang);
                        });
                    });
                }
                
            };
            ctrl.logOut = function () {
                $rootScope.logOut();
            };
        }],
        bindings: {
            settings: '=',
            style: '=',
        }
    });
})(window.angular);