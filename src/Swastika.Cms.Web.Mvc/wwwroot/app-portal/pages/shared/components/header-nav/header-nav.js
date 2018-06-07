(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-portal/pages/shared/components/header-nav/headerNav.html',
        controller: ['$rootScope', 'commonServices', function ($rootScope, commonServices) {
            var ctrl = this;
            ctrl.settings = null;
            ctrl.loadSettings = async function () {
                ctrl.settings = await commonServices.getSettings();
            }
            ctrl.changeLang = function (lang) {
                ctrl.settings.lang = lang;
                commonServices.setSettings(ctrl.settings);
            };
            ctrl.logOut = function () {
                $rootScope.logOut();
            }
        }],
        bindings: {
        }
    });
})(window.angular);