'use strict';
app.controller('Step2Controller', ['$scope', '$rootScope', '$timeout', '$location', '$http', 'commonServices', 'Step2Services'
    , function ($scope, $rootScope, $timeout, $location, $http, commonServices, services) {
        $scope.user = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: '',
        }
        $scope.register = async function () {
            $rootScope.isBusy = true;
            var result = await services.register($scope.user);
            if (result.isSucceed) {
                $rootScope.isBusy = false;
                window.location.href = '/backend';
            } else {
                if (result) { $rootScope.showMessage('', result.errors, 'danger'); }
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        }
    }]);
