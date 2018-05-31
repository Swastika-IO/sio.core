'use strict';
app.controller('DashboardController', ['$scope', '$rootScope', '$timeout', '$location', 'DashboardServices', function ($scope, $rootScope, $timeout, $location, dashboardServices) {
    $scope.pageClass = 'page-dashboard';
    $('.side-nav li').removeClass('active');
    $('.side-nav .page-dashboard').addClass('active');
    $scope.data = {
        totalPage: 0,
        totalArticle: 0,
        totalProduct: 0,
        totalUser: 0
    }
    $scope.users = [];
    $scope.$on('$viewContentLoaded', function () {
        $rootScope.isBusy = false;

    });
    $scope.getDashboardInfo = async function () {
        var response = await dashboardServices.getDashboardInfo();
        if (response.isSucceed) {
            $scope.data = response.data;
            $scope.$apply();
        }
        else {
            $rootScope.showErrors(response.errors);
            $scope.$apply();
        }
    }
}]);
