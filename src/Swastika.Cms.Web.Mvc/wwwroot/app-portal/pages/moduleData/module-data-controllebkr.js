'use strict';
app.controller('ModuleDataControllerbk', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'ModuleDataServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, moduleDataServices) {

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

        $scope.activedModuleData = null;
        $scope.relatedModuleDatas = [];
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

        $scope.getModuleData = async function (id) {
            $rootScope.isBusy = true;
            var resp = await moduleDataServices.getModuleData(id, 'be');
            if (resp.isSucceed) {
                $scope.activedModuleData = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.initModuleData = function () {
            if (!$rootScope.isBusy) {
                $rootScope.isBusy = true;
                moduleDataServices.initModuleData('be').then(function (response) {
                    if (response.isSucceed) {
                        $scope.activedModuleData = response.data;
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

        $scope.loadModuleData = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var moduleId = $routeParams.moduleId;
            var response = await moduleDataServices.getModuleData(moduleId, id, 'be');
            if (response.isSucceed) {
                $scope.activedModuleData = response.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadModuleDatas = async function (pageIndex) {
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
            var resp = await moduleDataServices.getModuleDatas($scope.request);
            if (resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, moduleData) {

                    $.each($scope.activedModuleDatas, function (i, e) {
                        if (e.moduleDataId == moduleData.id) {
                            moduleData.isHidden = true;
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

        $scope.removeModuleData = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await moduleDataServices.removeModuleData(id);
                if (resp.isSucceed) {
                    $scope.loadModuleDatas();
                }
                else {
                    $rootScope.showErrors(resp.errors);
                }
            }
        };

        $scope.saveModuleData = async function (moduleData) {
            moduleData.content = $('.editor-content').val();
            var resp = await moduleDataServices.saveModuleData(moduleData);
            if (resp.isSucceed) {
                $scope.activedModuleData = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
                //$location.path('/backend/moduleData/details/' + resp.data.id);
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

    }]);
