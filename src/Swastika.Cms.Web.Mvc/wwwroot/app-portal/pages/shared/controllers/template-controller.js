'use strict';
app.controller('TemplateController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'TemplateServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, templateServices) {
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
        $scope.folderType = 'Masters';
        $scope.folderTypes = [
            'Masters',
            'Layouts',
            'Pages',
            'Modules',
            'Products',
            'Articles',
            'Widgets',
        ];
        $scope.templateFile = {
            file: null,
            fullPath: '',
            folder: 'Template',
            title: '',
            description: ''
        };
        $scope.listUrl = '/backend/template/list/';
        $scope.activedTemplate = null;
        $scope.relatedTemplates = [];
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

        $scope.getTemplate = async function (id) {
            $rootScope.isBusy = true;
            var resp = await templateServices.getTemplate(id, 'be');
            if (resp.isSucceed) {
                $scope.activedTemplate = resp.data;
                $scope.listUrl = '/backend/template/list/' + resp.data.folderType;
                $scope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.loadParams = async function () {
            $rootScope.isBusy = true;
            $scope.folderType = $routeParams.folderType ? $routeParams.folderType : 'Masters';
            $scope.backUrl = '/backend/template/list/' + $routeParams.themeId;
            $scope.themeId = $routeParams.themeId;

        }

        $scope.loadTemplate = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await templateServices.getTemplate(id, 'be');
            if (response.isSucceed) {
                $scope.activedTemplate = response.data;
                $scope.listUrl = '/backend/template/list/' + response.data.templateId + '/' + response.data.folderType;
                $scope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadTemplates = async function (pageIndex) {
            $scope.request.key = $routeParams.themeId;
            $scope.folderType = this.folderType;
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
            var resp = await templateServices.getTemplates($scope.request, $scope.folderType);
            if (resp.isSucceed) {
                $scope.data = resp.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.removeTemplate = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await templateServices.removeTemplate(id);
                if (resp.isSucceed) {
                    $scope.loadTemplates();
                }
                else {
                    $rootScope.showErrors(resp.errors);
                }
            }
        };

        $scope.saveTemplate = async function () {
            $scope.activedTemplate.content = $('#content-razor').val();
            $scope.activedTemplate.scripts = $('#content-scripts').val();
            $scope.activedTemplate.styles = $('#content-styles').val();
            var resp = await templateServices.saveTemplate($scope.activedTemplate);
            if (resp.isSucceed) {
                $scope.activedTemplate = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
                //$location.path('/backend/template/details/' + resp.data.id);
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.initEditor = function () {
            setTimeout(function () {
                $.each($('.code-editor'), function (i, e) {
                    var container = $(this);
                    var editor = ace.edit(e);
                    var val = $(this).next('input').val();
                    editor.setValue(val);
                    if (container.hasClass('json')) {
                        editor.session.setMode("ace/mode/json");
                    }
                    else {
                        editor.session.setMode("ace/mode/razor");
                    }
                    editor.setTheme("ace/theme/chrome");

                    editor.session.setUseWrapMode(true);
                    editor.setOptions({
                        maxLines: Infinity
                    });
                    editor.getSession().on('change', function (e) {
                        // e.type, etc
                        $(container).parent().find('.code-content').val(editor.getValue());
                       
                    });
                });
            }, 200);
        };
    }]);
