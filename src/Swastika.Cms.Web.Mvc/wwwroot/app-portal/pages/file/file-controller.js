'use strict';
app.controller('FileController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'FileServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, fileServices) {
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

        $scope.activedFile = null;
        $scope.relatedFiles = [];
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

        $scope.getFile = async function (id) {
            $rootScope.isBusy = true;
            var resp = await fileServices.getFile(id, 'be');
            if (resp.isSucceed) {
                $scope.activedFile = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };
        $scope.loadFile = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await fileServices.getFile(id, 'be');
            if (response.isSucceed) {
                $scope.activedFile = response.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadFiles = async function (folder) {
            if (folder) {
                $scope.request.key += ($scope.request.key != '') ? '/' : '';
                $scope.request.key += folder;
            }

            var resp = await fileServices.getFiles($scope.request);
            if (resp.isSucceed) {

                ($scope.data = resp.data);
                $.each($scope.data.items, function (i, file) {

                    $.each($scope.activedFiles, function (i, e) {
                        if (e.fileId == file.id) {
                            file.isHidden = true;
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

        $scope.removeFile = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await fileServices.removeFile(id);
                if (resp.isSucceed) {
                    $scope.loadFiles();
                }
                else {
                    $rootScope.showErrors(resp.errors);
                }
            }
        };

        $scope.saveFile = async function (file) {
            file.content = $('.editor-content').val();
            var resp = await fileServices.saveFile(file);
            if (resp.isSucceed) {
                $scope.activedFile = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

    }]);
