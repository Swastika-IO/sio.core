'use strict';
app.controller('Step2Controller', ['$scope', '$rootScope', '$timeout', '$location', '$http', 'commonServices', 'Step2Services'
    , function ($scope, $rootScope, $timeout, $location, $http, commonServices, services) {
        $scope.user = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: '',
            isAgreed: false
        }
        $scope.register = async function () {            
            if (!$scope.user.isAgreed) {
                $rootScope.showMessage('Please agreed with our policy', 'warning');
            }
            else {
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
        }
    }]);
