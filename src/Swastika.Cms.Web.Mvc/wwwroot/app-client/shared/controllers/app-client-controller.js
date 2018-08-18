(function (angular) {
    'use strict';
    app.controller('AppClientController', ['$rootScope', '$scope', 'commonServices', 'authService', 'translatorService',
        function ($rootScope, $scope, commonServices, authService, translatorService) {
            $scope.lang = '';
            $scope.isInit = false;
            $scope.init = async function (lang) {
                if (!$rootScope.isBusy) {
                    $rootScope.isBusy = true;
                    commonServices.fillSettings(lang).then(function (response) {                        
                        $scope.isInit = true;
                        $rootScope.settings = response;
                        if ($rootScope.settings) {
                            $scope.settings = $rootScope.settings;
                            $rootScope.translator.fillTranslator(lang).then(function () {
                                authService.fillAuthData().then(function (response) {
                                    $rootScope.authentication = authService.authentication;
                                });
                                $rootScope.isBusy = false;
                                $scope.$apply();
                            });

                        } else {
                            $rootScope.isBusy = false;
                        }
                    });
                }
            }
            $scope.translate = $rootScope.translate;
        }]);
})(window.angular);