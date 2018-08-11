(function (angular) {
    'use strict';
    app.controller('AppClientController', ['$rootScope', '$scope', 'commonServices', 'authService', 'translatorService',
        function ($rootScope, $scope, commonServices, authService, translatorService) {
            $scope.lang = '';
            $scope.isInit = false;
            $scope.translator = {};
            $scope.init = async function (lang) {
                commonServices.fillSettings(lang).then(function (response) {
                    $scope.translator = translatorService;
                    $scope.isInit = true;
                    $rootScope.settings = response;
                    $scope.settings = response;
                    translatorService.fillTranslator($rootScope.settings.lang).then(function () {
                        authService.fillAuthData().then(function (response) {
                            $rootScope.authentication = authService.authentication;
                        });
                        $scope.$apply();
                    });
                    
                });
            }
            $scope.translate = $rootScope.translate;
        }]);
})(window.angular);