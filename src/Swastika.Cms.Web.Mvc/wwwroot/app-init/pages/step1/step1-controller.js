'use strict';
app.controller('Step1Controller', ['$scope', '$rootScope', '$timeout', '$location', '$http',
    'commonServices', 'Step1Services',
    function ($scope, $rootScope, $timeout, $location, $http, commonServices, step1Services) {
        $scope.initCmsModel = {
            isUseLocal: false,
            localDbConnectionString: 'Server=(localdb)\\mssqllocaldb;Database=aspnet-swastika.Cms.Db;Trusted_Connection=True;MultipleActiveResultSets=true',
            dataBaseServer: '',
            dataBaseName: '',
            dataBaseUser: '',
            dataBasePassword: '',
            isUseLocal: '',
            adminPassword: '',
            lang: 'en-us'
        }
        $scope.settings = null;
        $scope.loadSettings = async function () {
            var result = await commonServices.getSettings();
            if (result.isSucceed) {
                $scope.settings = result.data;
                $scope.$apply();
            }
        }

        $scope.initCms = async function () {
            $rootScope.isBusy = true;
            var result = await step1Services.initCms($scope.initCmsModel);
            if (result.isSucceed) {
                $rootScope.isBusy = false;
                $location.path('/portal/init/step2');
            }
            else {
                if (result) { $rootScope.showMessage('', result.errors, 'danger'); }
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        }
    }]);
