(function (angular) {
    'use strict';
    app.controller('AppClientController', ['$rootScope', '$scope', 'commonServices', 'translatorService',
        function ($rootScope, $scope, commonServices, translatorService) {
            $scope.translator = translatorService;
            $scope.lang = '';
            $scope.init = function (lang) {
                $scope.lang = lang;
                commonServices.fillSettings(lang).then(function (response) {
                    $rootScope.settings = response;
                    translatorService.fillTranslator($rootScope.settings.lang);
                });
            };
            $scope.translate = function (keyword) {
                return $scope.translator.get(keyword, $scope.lang);
            }
        }]);
})(window.angular);