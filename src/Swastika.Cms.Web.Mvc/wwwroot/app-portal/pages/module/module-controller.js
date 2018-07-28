'use strict';
app.controller('ModuleController', ['$scope', '$rootScope', '$routeParams', '$timeout'
    , '$location', 'authService', 'ModuleServices', 'ModuleDataServices',
    function ($scope, $rootScope, $routeParams, $timeout,
        $location, authService, moduleServices, moduleDataServices) {
        $scope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'CreatedDateTime',
            direction: '1',
            fromDate: null,
            toDate: null,
            keyword: '',
            key: ''
        };
        $scope.defaultAttr = {
            name: '',
            options: [],
            priority: 0,
            dataType: 0,
            isGroupBy: false,
            isSelect: false,
            isDisplay: true,
            width: 3
        };
        $scope.dataTypes = $rootScope.configurations.dataTypes;
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
            if (resp && resp.isSucceed) {
                $scope.activedModule = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
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
                $location.path('/backend/module/list/');
                $scope.$apply();
            }
        };

        $scope.loadModuleDatas = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await moduleServices.getModule(id, 'fe');
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

        $scope.loadMoreModuleDatas = async function (pageIndex) {
            $scope.request.key = $scope.activedModule.id;
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
            if (resp && resp.isSucceed) {

                $scope.activedModule.data = resp.data;
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        }

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
            if (resp && resp.isSucceed) {

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
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.removeModule = function (id) {
            $rootScope.showConfirm($scope, 'removeModuleConfirmed', [id], null, 'Remove Module', 'Are you sure');
        }

        $scope.removeModuleConfirmed = async function (id) {
            var result = await moduleServices.removeModule(id);
            if (result.isSucceed) {
                $scope.loadModules();
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }


        $scope.saveModule = async function (module) {
            module.content = $('.editor-content').val();
            if (module.title) {
                module.name = module.title.replace(/ /g, "_");//(' ', '_');
            }
            var resp = await moduleServices.saveModule(module);
            if (resp && resp.isSucceed) {
                $scope.activedModule = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                if (!$routeParams.id) {
                    $location.path('/backend/module/list/');
                }
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };
        $scope.addAttr = function () {
            if ($scope.activedModule) {
                var t = angular.copy($scope.defaultAttr);
                $scope.activedModule.columns.push(t);
            }
        }

        $scope.addOption = function (col, index) {
            var val = angular.element('#option_' + index).val();
            col.options.push(val);
            angular.element('#option_' + index).val('');
        }

        $scope.generateName = function (col) {
            col.name = col.title.replace(/[^a-zA-Z0-9]+/g, '_')
                .replace(/([A-Z]+)([A-Z][a-z])/g, '$1-$2')
                .replace(/([a-z])([A-Z])/g, '$1-$2')
                .replace(/([0-9])([^0-9])/g, '$1-$2')
                .replace(/([^0-9])([0-9])/g, '$1-$2')
                .replace(/-+/g, '_')
                .toLowerCase();
        }

        $scope.removeAttr = function (index) {
            if ($scope.activedModule) {

                $scope.activedModule.columns.splice(index, 1);
            }
        }

        $scope.removeData = function (id) {
            if ($scope.activedModule) {
                $rootScope.showConfirm($scope, 'removeDataConfirmed', [id], null, 'Remove Data', 'Are you sure');
            }
        }

        $scope.removeDataConfirmed = async function (id) {
            var result = await moduleDataServices.removeModuleData(id);
            if (result.isSucceed) {
                $scope.loadModuleDatas();
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }

    }]);
