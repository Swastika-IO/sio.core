'use strict';
app.controller('AppPortalController', ['$rootScope', '$scope', 'ngAppSettings', '$location'
    , 'CommonServices', 'AuthService', 'TranslatorService', 'SiteConfigurationService', 'RoleServices',
    function ($rootScope, $scope, ngAppSettings, $location, commonServices, authService, translatorService, configurationService, roleServices) {
        $scope.isInit = false;
        $scope.isAdmin = false;
        $scope.translator = translatorService;
        $scope.configurationService = configurationService;
        $scope.lang = '';
        $scope.settings = {};
        $scope.init = function () {
            if (!$rootScope.isBusy) {
                $rootScope.isBusy = true;
                commonServices.fillSettings().then(function (response) {
                    $scope.isInit = true;
                    $rootScope.settings = response;
                    $scope.settings = response;
                    if ($rootScope.settings) {

                        $rootScope.translator.fillTranslator($rootScope.settings.lang).then(function () {
                            $rootScope.configurationService.fillConfigurations($rootScope.settings.lang).then(function () {
                                authService.fillAuthData().then(function (response) {
                                    $rootScope.authentication = authService.authentication;
                                    if (!authService.authentication || !authService.authentication.isAuth) {
                                        window.top.location.href = '/portal/login';
                                    }
                                    else {
                                        $scope.isAdmin = authService.authentication.isAdmin;
                                        if (!$scope.isAdmin) {

                                            roleServices.getPermissions().then(function (response) {

                                                if (response && response.isSucceed) {

                                                    $scope.isInit = true;
                                                    $scope.roles = response.data;
                                                    $rootScope.isBusy = false;
                                                    $scope.$apply();
                                                }
                                                else {
                                                    window.top.location.href = '/portal/login';

                                                }
                                            });
                                        }
                                    }
                                });
                                $rootScope.isBusy = false;
                                $scope.$apply();
                            });
                        });

                    } else {
                        $rootScope.isBusy = false;
                    }
                });
            }
        };
    }]);
