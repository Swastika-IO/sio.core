'use strict';
app.controller('TeamController', ['$scope', '$rootScope', 'ngAppSettings', '$timeout', '$location', 'AuthService', 'userServices', function ($scope, $rootScope, ngAppSettings, $timeout, $location, authService, userServices) {
    $rootScope.page = 'page-managers';
    $scope.data = {
        pageIndex: 0,
        pageSize: 20,
        totalItems: 0,
    };
    $('.side-nav li').removeClass('active');
    $('.side-nav .page-users').addClass('active');
    $scope.users = [];
    $scope.$on('$viewContentLoaded', function () {
        $scope.loadUsers(0);
    });
    $scope.isBusy = false;
    $scope.paging = {
        pageIndex: 0,
        pageSize: 10,
        totalPage: 1,
        total: 0
    };
    $scope.request = {
        keyword: '',
        pageIndex: 0,
        pageSize: 20,
        orderBy: 'Fullname',
        direction: '0'
    };   
    $scope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };
    $scope.keyword = '';
    $scope.searchUsers = function ($event) {
        $scope.loadUsers(0, $('#btn-search'));
    }
    $scope.base64 = null;
    $scope.importUsers = function () {
        
        $scope.base64 = $('#hid-import-file').val();
        if ($scope.base64) {
            $scope.isBusy = true;
            userServices.importUsers($scope.base64).then(function (results) {
                var resp = results.data;

                if (resp.isSucceed) {
                    $scope.users = resp.data;
                }
                $scope.isBusy = false;
            });
        }
    }
    $scope.loadUsers = function (pageIndex = 0, btn) {
        if (!$scope.isBusy) {
            $scope.isBusy = true;
            if (pageIndex !== undefined) {
                $scope.request.pageIndex = pageIndex;
            }

            userServices.getUsers($scope.request).then(function (results) {
                if (results.data.isSucceed) {
                    $scope.data = results.data.data;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    if ($scope.data.totalItems==0) {
                        $scope.message = 'Kết quả tìm kiếm: Không tìm thấy';
                        $scope.messageClass = 'warning';
                    }
                }
                $scope.isBusy = false;
            }, function (error) {
                //alert(error.data.message);
                $scope.isBusy = false;
            });
        }
    }

    $scope.updateRoleStatus = function (userInRole) {
        userServices.updateRoleStatus(userInRole).then(function (results) {
            $('#message').fadeIn();
            $timeout(function () {
                $('#message').fadeOut();
            }, 1500);
        }, function (error) {
            $('#message').html(JSON.stringify(error));
            $('#message').show();
            //alert(error.data.message);
        });

    }
    $scope.removeUser = function (user) {
        if (confirm("Remove this user ?")) {
            if (!$scope.isBusy) {
                $scope.isBusy = true;

                userServices.removeUser(user).then(function (results) {
                    $scope.isBusy = false;
                    $scope.loadUsers();
                }, function (error) {
                    $scope.isBusy = false;
                    $scope.errors.push(error);
                });
            }
        }


    }
}]);