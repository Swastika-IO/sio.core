(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-portal/pages/shared/components/header-nav/headerNav.html',
        controller: ['commonServices', function (commonServices) {
            var ctrl = this;
            ctrl.settings = commonServices.getSettings();
            ctrl.changeLang = function (lang) {
                ctrl.settings.lang = lang;
                commonServices.setSettings(ctrl.settings);
            }
        }],
        bindings: {
        }
    });
})(window.angular);