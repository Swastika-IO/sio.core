'use strict';
app.controller('AppSettingsController', 
['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 
'authService','commonServices', 'AppSettingsServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, commonServices, appSettingsServices) {

        $scope.appSettings = null;
        $scope.errors = [];

        $scope.getAppSettings = async function (id) {
            $rootScope.isBusy = true;
            var resp = await appSettingsServices.getAppSettings();
            if (resp && resp.isSucceed) {
                $scope.appSettings = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };
        $scope.loadAppSettings = async function () {
            $rootScope.isBusy = true;

            var id = $routeParams.id;
            var response = await appSettingsServices.getAppSettings();
            if (response.isSucceed) {
                $scope.appSettings = response.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }

            var result = await commonServices.getSettings();
            if (result.isSucceed) {
                $scope.settings = result.data;
                $scope.$apply();
            }
        };

        $scope.saveAppSettings = async function (appSettings) {
            var resp = await appSettingsServices.saveAppSettings(appSettings);
            if (resp && resp.isSucceed) {
                $scope.appSettings = resp.data;
                $rootScope.showMessage('success', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

    }]);
