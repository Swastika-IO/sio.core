'use strict';
app.controller('CultureController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'CultureServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, cultureServices) {
        $scope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'Priority',
            direction: '0',
            fromDate: null,
            toDate: null,
            keyword: ''
        };
        $scope.icons = [
            'flag-icon-us',
            'flag-icon-vi',
            'flag-icon-gb'
        ];
        $scope.activedCulture = null;

        $scope.relatedCultures = [];

        $rootScope.isBusy = false;

        $scope.data = {
            pageIndex: 0,
            pageSize: 1,
            totalItems: 0
        };

        $scope.errors = [];

        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        $scope.getCulture = async function (id) {
            $rootScope.isBusy = true;
            var resp = await cultureServices.getCulture(id, 'be');
            if (resp && resp.isSucceed) {
                $scope.activedCulture = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.syncTemplates = async function (id) {
            var response = await cultureServices.syncTemplates(id);
            if (response.isSucceed) {
                $scope.activedCulture = response.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };

        $scope.loadCulture = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await cultureServices.getCulture(id, 'be');
            if (response.isSucceed) {
                $scope.activedCulture = response.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadCultures = async function (pageIndex) {
            if (pageIndex != undefined) {
                $scope.request.pageIndex = pageIndex;
            }
            if ($scope.request.fromDate != null) {
                var d = new Date($scope.request.fromDate);
                $scope.request.fromDate = d.toISOString();
            }
            if ($scope.request.toDate != null) {
                $scope.request.toDate = $scope.request.toDate.toISOString();
            }
            var resp = await cultureServices.getCultures($scope.request);
            if (resp && resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, culture) {

                    $.each($scope.activedCultures, function (i, e) {
                        if (e.cultureId == culture.id) {
                            culture.isHidden = true;
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

        $scope.saveCulture = async function (culture) {
            culture.content = $('.editor-content').val();
            var resp = await cultureServices.saveCulture(culture);
            if (resp && resp.isSucceed) {
                $scope.activedCulture = resp.data;
                $rootScope.showMessage('success', 'success');
                $rootScope.isBusy = false;
                $rootScope.updateSettings();
                $location.path('/backend/culture/list');
                $scope.$apply();
                
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.removeCulture = function (id) {
            $rootScope.showConfirm($scope, 'removeCultureConfirmed', [id], null, 'Remove Culture', 'Are you sure');
        }

        $scope.removeCultureConfirmed = async function (id) {
            var result = await cultureServices.removeCulture(id);
            if (result.isSucceed) {
                $scope.loadCultures();
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }
    }]);
