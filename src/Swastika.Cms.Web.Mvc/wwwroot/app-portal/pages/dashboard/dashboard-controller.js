'use strict';
app.controller('DashboardController', ['$scope', '$rootScope', '$timeout', '$location', function ($scope, $rootScope, $timeout, $location) {
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
    $scope.getUserDemographicInfo = function () {
        //dashboardServices.getUserDemographicInfo().then(function (results) {
        //    //$scope.loadData();
        //}, function (error) {
        //    //alert(error.data.message);
        //});
    }
}]);
