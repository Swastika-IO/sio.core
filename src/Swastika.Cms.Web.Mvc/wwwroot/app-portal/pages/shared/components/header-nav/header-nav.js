(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-portal/pages/shared/components/header-nav/headerNav.html',
        controller: ['$rootScope', function ($rootScope) {
            var ctrl = this;
            ctrl.settings = $rootScope.siteSettings;
            ctrl.changeLang = function (lang) {
                ctrl.settings.lang = lang;
                commonServices.setSiteSettings(ctrl.settings);
            }
        }],
        bindings: {
        }
    });
})(window.angular);