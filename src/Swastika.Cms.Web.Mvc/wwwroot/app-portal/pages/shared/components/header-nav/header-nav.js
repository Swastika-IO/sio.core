(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-portal/pages/shared/components/header-nav/headerNav.html',
        controller: ['commonServices', function (commonServices) {
            var ctrl = this;
            ctrl.settings = commonServices.getSiteSettings();
            ctrl.changeLang = function (lang) {
                ctrl.settings.lang = lang;
                commonServices.setSiteSettings(ctrl.settings);
            }
        }],
        bindings: {
        }
    });
})(window.angular);