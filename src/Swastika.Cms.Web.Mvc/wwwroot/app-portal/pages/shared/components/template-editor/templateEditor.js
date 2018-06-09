modules.component('templateEditor', {
    templateUrl: '/app-portal/pages/shared/components/template-editor/templateEditor.html',
    controller: ['$rootScope', '$scope', 'commonServices', function ($rootScope, $scope, commonServices) {
        var vm = this;
        vm.templates = [];
        vm.activedId = -1;
        vm.masters = [];
        vm.activedMaster = {};
        vm.activedName = '';
        vm.folder = '';
        vm.activedTemplate = {};
        vm.request = {
            pageSize: 10,
            pageIndex: 0,
            orderBy: 'CreatedDateTime',
            direction: 1,
            keyword: ''
        };
        vm.settings = {
            async: true,
            crossDomain: true,
            url: "",
            method: "POST",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            data: vm.request
        };

        vm.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        vm.loadTemplates = async function (activedId, activedName, folder) {

            if (folder) {
                vm.folder = folder;
                vm.activedId = activedId;
                vm.activedName = activedName;
            }
            else if (vm.template) {
                vm.folder = vm.template.folderType;
                vm.activedId = vm.template.id;
                vm.activedName = vm.template.fileName;
            }
            var url = '/api/' + $rootScope.settings.lang + '/template/list';
            var request = {
                pageSize: null,
                pageIndex: 0,
                orderBy: 'fileName',
                direction: 0,
                key: $rootScope.settings.themeId,
                keyword: vm.template.folderType,
                url: url
            }
            var req = {
                method: 'POST',
                url: url,
                data: JSON.stringify(request)
            };
            var result = await commonServices.getApiResult(req);
            if (result.isSucceed) {
                vm.initTemplate(result, vm.activedId, vm.activedName);
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $rootScope.isBusy = false;
                $scope.$apply();
            }

        };
        vm.initTemplate = function (response, activedId, activedName) {
            const ph = {};
            var isInit = false;
            const promise = new Promise(resolve => {
                ph.resolve = resolve;
            });
            vm.templates = response.data.items;
            if (vm.templates != undefined && vm.templates.length > 0) {
                var newTemplate = angular.copy(vm.templates[0]);
                newTemplate.id = 0;
                newTemplate.fileName = '_blank';
                newTemplate.content = "<div></div>";
                vm.templates.splice(0, 0, newTemplate);
                var templates = vm.templates;
                $.each(templates, function (i, e) {
                    if (e.id == activedId) {
                        vm.activedTemplate = e;
                    }
                    if (e.fileName == activedName) {
                        vm.activedTemplate = e;
                    }
                });
                vm.updateEditors();
                $rootScope.isBusy = false;
                $scope.$apply();
                ph.resolve(true);
            }
            return promise;
        };
        vm.updateEditors = function () {
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
                    //editor.setReadOnly(true);

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
    }],
    bindings: {
        template: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});