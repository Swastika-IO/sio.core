
modules.component('moduleForm', {
    templateUrl: '/app-portal/pages/shared/components/module-data/module-form.html',
    controller: ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'ModuleDataServices',
        function ($scope, $rootScope, $routeParams, $timeout, $location, authService, moduleDataServices) {
            var ctrl = this;
            $rootScope.isBusy = false;


            ctrl.initEditor = function () {
                $rootScope.initEditor();
            }
            ctrl.initModuleForm = async function () {
                var resp = null;
                if (!ctrl.moduleId) {
                    resp = await moduleDataServices.initModuleForm(ctrl.name);
                }
                else {
                    resp = await moduleDataServices.getModuleData(ctrl.moduleId, ctrl.d, 'be');
                }
                if (resp && resp.isSucceed) {
                    ctrl.data = resp.data;
                    $scope.$apply();
                    ctrl.initEditor();
                }
                else {
                    if (resp) { $rootScope.showErrors(resp.errors); }
                    $scope.$apply();
                }

            };

            ctrl.loadModuleData = async function () {
                $rootScope.isBusy = true;
                var id = $routeParams.id;
                var response = await moduleDataServices.getModuleData(ctrl.moduleId, ctrl.d, 'be');
                if (response.isSucceed) {
                    ctrl.data = response.data;
                    $rootScope.initEditor();
                    $scope.$apply();
                }
                else {
                    $rootScope.showErrors(response.errors);
                    $scope.$apply();
                }
            };
            ctrl.saveModuleData = async function () {
                var form = $('#module-' + ctrl.data.moduleId);
                $.each(ctrl.data.dataProperties, function (i, e) {
                    switch (e.dataType) {
                        case 5:
                            e.value = $(form).find('.' + e.name).val();
                            break;
                        default:
                            e.value = e.value ? e.value.toString() : null;
                            break;
                    }
                });
                var resp = await moduleDataServices.saveModuleData(ctrl.data);
                if (resp && resp.isSucceed) {
                    ctrl.data = resp.data;
                    $rootScope.showMessage('Thành công', 'success');
                    $rootScope.isBusy = false;
                    $scope.$apply();
                    //$location.path('/backend/moduleData/details/' + resp.data.id);
                }
                else {
                    if (resp) { $rootScope.showErrors(resp.errors); }
                    $scope.$apply();
                }
            };


        }],
    bindings: {
        moduleId: '=',
        d: '=',
        name: '=',
        backUrl: '='
    }
});


modules.component('moduleFormEditor', {
    templateUrl: '/app-portal/pages/shared/components/module-data/module-form-editor.html',
    controller: ['$rootScope', function ($rootScope) {
        var ctrl = this;
        this.dataTypes = {
            'string': 0,
            'int': 1,
            'image': 2,
            'icon': 3,
            'codeEditor': 4,
            'html': 5,
            'textArea': 6,
            'boolean': 7,
            'mdTextArea': 8
        };

    }
    ],
    bindings: {
        data: '=',
    }
});

modules.component('moduleFormPreview', {
    templateUrl: '/app-portal/pages/shared/components/module-data/module-data-preview.html',
    controller: ['$rootScope', function ($rootScope) {
        var ctrl = this;
    }
    ],
    bindings: {
        data: '=',
        width: '=',
    }
});