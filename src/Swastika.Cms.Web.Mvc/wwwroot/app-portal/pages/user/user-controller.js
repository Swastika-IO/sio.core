'use strict';
app.controller('UserController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'UserServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, userServices) {
        $scope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'CreatedDateTime',
            direction: '1',
            fromDate: null,
            toDate: null,
            keyword: ''
        };
        
        $scope.mediaFile = {
            file: null,
            fullPath: '',
            folder: 'User',
            title: '',
            description: ''
        };
        $scope.activedUser = null;
        $scope.relatedUsers = [];
        $rootScope.isBusy = false;
        $scope.data = {
            pageIndex: 0,
            pageSize: 1,
            totalItems: 0,
        };
        $scope.errors = [];

        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        $scope.loadUser = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await userServices.getUser(id, 'be');
            if (response.isSucceed) {
                $scope.activedUser = response.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };

        $scope.loadUsers = async function (pageIndex) {
            if (pageIndex != undefined) {
                $scope.request.pageIndex = pageIndex;
            }

            var resp = await userServices.getUsers($scope.request);
            if (resp && resp.isSucceed) {
                $scope.data = resp.data;
                $.each($scope.data.items, function (i, user) {

                    $.each($scope.data, function (i, e) {
                        if (e.userId == user.id) {
                            user.isHidden = true;
                        }
                    })
                })
                setTimeout(function () {
                    $('[data-toggle="popover"]').popover({
                        html: true,
                        content: function () {
                            var content = $(this).next('.popover-body');
                            return $(content).html();
                        },
                        title: function () {
                            var title = $(this).attr("data-popover-content");
                            return $(title).children(".popover-heading").html();
                        }
                    });
                }, 200);
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.removeUser = function (id) {
            $rootScope.showConfirm($scope, 'removeUserConfirmed', [id], null, 'Remove User', 'Are you sure');
        }

        $scope.removeUserConfirmed = async function (id) {
            var result = await userServices.removeUser(id);
            if (result.isSucceed) {
                $scope.loadUsers();
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }

        $scope.saveUser = async function (user) {
            //if (user.avatar != user.avatarUrl) {
            //    user.avatar = user.avatarUrl;
            //}
            var resp = await userServices.saveUser(user);
            if (resp && resp.isSucceed) {
                //$scope.activedUser = resp.data;
                $rootScope.showMessage('success', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.register = async function (user) {
            var resp = await userServices.register(user);
            if (resp && resp.isSucceed) {
                $scope.activedUser = resp.data;
                $rootScope.showMessage('success', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.updateRoleStatus = async function (nav) {
            var userRole = {
                userId: nav.userId,
                roleId: nav.roleId,
                roleName: nav.description,
                isUserInRole: nav.isActived
            };
            var resp = await userServices.updateRoleStatus(userRole);
            if (resp && resp.isSucceed) {
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
