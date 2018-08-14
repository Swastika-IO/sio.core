(function (angular) {
    'use strict';
    app.controller('AppPortalController', ['$rootScope', '$scope', '$location', 'commonServices', 'authService', 'translatorService',
        function ($rootScope, $scope, $location, commonServices, authService, translatorService) {
            $scope.isInit = false;
            $scope.translator = translatorService;
            $scope.lang = '';
            $scope.settings = {};
            $scope.init = function () {
                if (!$rootScope.isBusy) {
                    $rootScope.isBusy = true;
                    commonServices.fillSettings().then(function (response) {
                        $scope.isInit = true;
                        $rootScope.settings = response;
                        if ($rootScope.settings) {

                            $rootScope.translator.fillTranslator($rootScope.settings.lang).then(function () {
                                authService.fillAuthData().then(function (response) {
                                    $rootScope.authentication = authService.authentication;
                                    if (!authService.authentication.isAuth || !authService.authentication.isAdmin) {
                                        authService.authentication.referredUrl = $location.$$url;
                                        $location.path('/backend/login');
                                    }
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
            //$scope.translate = function (keyword) {
            //    if ($scope.isInit) {
            //        return $scope.translator.get(keyword, $scope.lang);
            //    }
            //    else {
            //        return keyword;
            //    }
            //}
        }]);
})(window.angular);