'use strict';
app.controller('ModuleController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'ModuleServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, moduleServices) {
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

        $scope.activedModule = null;
        $scope.relatedModules = [];
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

        $scope.getModule = async function (id) {
            $rootScope.isBusy = true;
            var resp = await moduleServices.getModule(id, 'be');
            if (resp.isSucceed) {
                $scope.activedModule = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.initModule = function () {
            if (!$rootScope.isBusy) {
                $rootScope.isBusy = true;
                moduleServices.initModule('be').then(function (response) {
                    if (response.isSucceed) {
                        $scope.activedModule = response.data;
                        $rootScope.initEditor();
                    }
                    $rootScope.isBusy = false;
                    $scope.$apply();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $rootScope.isBusy = false;
                    //$("html, body").animate({ "scrollTop": "0px" }, 500);
                });
            }
        };

        $scope.loadModule = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await moduleServices.getModule(id, 'be');
            if (response.isSucceed) {
                $scope.activedModule = response.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadModules = async function (pageIndex) {
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
            var resp = await moduleServices.getModules($scope.request);
            if (resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, module) {

                    $.each($scope.activedModules, function (i, e) {
                        if (e.moduleId == module.id) {
                            module.isHidden = true;
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
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.removeModule = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await moduleServices.removeModule(id);
                if (resp.isSucceed) {
                    $scope.loadModules();
                }
                else {
                    $rootScope.showErrors(resp.errors);
                }
            }
        };

        $scope.saveModule = async function (module) {
            module.content = $('.editor-content').val();
            var resp = await moduleServices.saveModule(module);
            if (resp.isSucceed) {
                $scope.activedModule = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
                //$location.path('/backend/module/details/' + resp.data.id);
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

    }]);
