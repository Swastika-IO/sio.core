'use strict';
app.controller('TemplateController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'TemplateServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, templateServices) {
        var ctrl = this;
        ctrl.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'CreatedDateTime',
            direction: '1',
            fromDate: null,
            toDate: null,
            keyword: ''
        };
        ctrl.folderType = 'Masters';
        ctrl.folderTypes = [
            'Masters',
            'Layouts',
            'Pages',
            'Modules',
            'Products',
            'Articles',
            'Widgets',
        ];
        ctrl.templateFile = {
            file: null,
            fullPath: '',
            folder: 'Template',
            title: '',
            description: ''
        };
        ctrl.listUrl = '/backend/template/list/';
        ctrl.activedTemplate = null;
        ctrl.relatedTemplates = [];
        $rootScope.isBusy = false;
        ctrl.data = {
            pageIndex: 0,
            pageSize: 1,
            totalItems: 0,
        };
        ctrl.errors = [];

        ctrl.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        ctrl.getTemplate = async function (id) {
            $rootScope.isBusy = true;
            var resp = await templateServices.getTemplate(id, 'be');
            if (resp.isSucceed) {
                ctrl.activedTemplate = resp.data;
                ctrl.listUrl = '/backend/template/list/' + resp.data.folderType;
                ctrl.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        ctrl.loadParams = async function () {
            $rootScope.isBusy = true;
            ctrl.folderType = $routeParams.folderType ? $routeParams.folderType : 'Masters';
            ctrl.backUrl = '/backend/template/list/' + $routeParams.themeId;
            ctrl.themeId = $routeParams.themeId;

        }

        ctrl.loadTemplate = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await templateServices.getTemplate(id, 'be');
            if (response.isSucceed) {
                ctrl.activedTemplate = response.data;
                ctrl.listUrl = '/backend/template/list/' + response.data.templateId + '/' + response.data.folderType;
                ctrl.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        ctrl.loadTemplates = async function (pageIndex) {
            ctrl.request.key = $routeParams.themeId;
            ctrl.folderType = this.folderType;
            if (pageIndex != undefined) {
                ctrl.request.pageIndex = pageIndex;
            }
            if (ctrl.request.fromDate != null) {
                var d = new Date(ctrl.request.fromDate);
                ctrl.request.fromDate = d.toISOString();
            }
            if (ctrl.request.toDate != null) {
                ctrl.request.toDate = ctrl.request.toDate.toISOString();
            }
            var resp = await templateServices.getTemplates(ctrl.request, ctrl.folderType);
            if (resp.isSucceed) {
                ctrl.data = resp.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        ctrl.removeTemplate = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await templateServices.removeTemplate(id);
                if (resp.isSucceed) {
                    ctrl.loadTemplates();
                }
                else {
                    $rootScope.showErrors(resp.errors);
                }
            }
        };

        ctrl.saveTemplate = async function () {
            var resp = await templateServices.saveTemplate(ctrl.activedTemplate);
            if (resp.isSucceed) {
                ctrl.activedTemplate = resp.data;
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

        ctrl.initEditor = function () {
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
