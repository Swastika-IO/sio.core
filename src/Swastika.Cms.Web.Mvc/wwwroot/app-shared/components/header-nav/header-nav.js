(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-shared/components/header-nav/headerNav.html',
        controller: ['$rootScope', 'commonServices', 'translatorService', function ($rootScope, commonServices, translatorService) {
            var ctrl = this;
            ctrl.settings = null;
            ctrl.loadSettings = async function () {
                ctrl.settings = await commonServices.getSettings();
            }
            ctrl.changeLang = function (lang) {
                ctrl.settings.lang = lang;
                commonServices.setSettings(ctrl.settings).then(function () {
                    translatorService.reset(lang).then(function () {
                        window.top.location = location.href;
                    });
                });
            };
            ctrl.logOut = function () {
                $rootScope.logOut();
            }
        }],
        bindings: {
        }
    });
})(window.angular);