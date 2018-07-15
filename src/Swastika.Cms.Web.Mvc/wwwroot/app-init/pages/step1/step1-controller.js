'use strict';
app.controller('Step1Controller', ['$scope', '$rootScope', '$timeout', '$location', '$http',
    'commonServices', 'Step1Services',
    function ($scope, $rootScope, $timeout, $location, $http, commonServices, step1Services) {
        $scope.initCmsModel = {
            isUseLocal: false,
            localDbConnectionString: 'Server=(localdb)\\MSSQLLocalDB;Initial Catalog=sw-cms.db;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True',
            sqliteDbConnectionString: 'Data Source=sw-cms.db',
            localDbName: 'sw-cms.db',
            dataBaseServer: '',
            dataBaseName: '',
            dataBaseUser: '',
            dataBasePassword: '',
            adminPassword: '',
            lang: 'en-us',
            isSqlite: false
        }
        $scope.settings = null;
        $scope.loadSettings = async function () {
            var result = await commonServices.getSettings();
            if (result.isSucceed) {
                $scope.settings = result.data;
                $scope.$apply();
            }
        }
        $scope.updateLocalDbName = function () {
            $scope.initCmsModel.localDbConnectionString = 'Server=(localdb)\\mssqllocaldb;Database=' + $scope.initCmsModel.localDbName + ';Trusted_Connection=True;MultipleActiveResultSets=true';
            $scope.initCmsModel.sqliteDbConnectionString = 'Data Source=' + $scope.initCmsModel.localDbName;
        }
        $scope.initCms = async function () {
            $rootScope.isBusy = true;
            var result = await step1Services.initCms($scope.initCmsModel);
            if (result.isSucceed) {
                $rootScope.isBusy = false;
                window.location.href = '/portal/init/step2';
            }
            else {
                if (result) { $rootScope.showMessage('', result.errors, 'danger'); }
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        }
    }]);
