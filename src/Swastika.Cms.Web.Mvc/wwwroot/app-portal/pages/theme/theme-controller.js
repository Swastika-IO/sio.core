'use strict';
app.controller('ThemeController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'ThemeServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, themeServices) {
        $scope.request = {
            themeSize: '10',
            themeIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'Priority',
            direction: '0',
            fromDate: null,
            toDate: null,
            keyword: ''
        };

        $scope.activedTheme = null;

        $scope.relatedThemes = [];

        $rootScope.isBusy = false;

        $scope.data = {
            themeIndex: 0,
            themeSize: 1,
            totalItems: 0
        };

        $scope.errors = [];

        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        $scope.getTheme = async function (id) {
            $rootScope.isBusy = true;
            var resp = await themeServices.getTheme(id, 'be');
            if (resp && resp.isSucceed) {
                $scope.activedTheme = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.loadTheme = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await themeServices.getTheme(id, 'be');
            if (response.isSucceed) {
                $scope.activedTheme = response.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadThemes = async function (themeIndex) {
            if (themeIndex != undefined) {
                $scope.request.themeIndex = themeIndex;
            }
            if ($scope.request.fromDate != null) {
                var d = new Date($scope.request.fromDate);
                $scope.request.fromDate = d.toISOString();
            }
            if ($scope.request.toDate != null) {
                $scope.request.toDate = $scope.request.toDate.toISOString();
            }
            var resp = await themeServices.getThemes($scope.request);
            if (resp && resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, theme) {

                    $.each($scope.activedThemes, function (i, e) {
                        if (e.themeId == theme.id) {
                            theme.isHidden = true;
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

        $scope.saveTheme = async function (theme) {
            theme.content = $('.editor-content').val();
            var resp = await themeServices.saveTheme(theme);
            if (resp && resp.isSucceed) {
                $scope.activedTheme = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $rootScope.updateSettings();
                $scope.$apply();
                //$location.path('/backend/theme/details/' + resp.data.id);
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.removeTheme = function (id) {
            $rootScope.showConfirm($scope, 'removeThemeConfirmed', [id], null, 'Remove Theme', 'Are you sure');
        }

        $scope.removeThemeConfirmed = async function (id) {
            var result = await themeServices.removeTheme(id);
            if (result.isSucceed) {
                $scope.loadThemes();
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }
    }]);
