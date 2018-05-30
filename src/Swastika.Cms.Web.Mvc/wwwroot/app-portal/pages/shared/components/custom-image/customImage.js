
//modules.controller('ImageController', );
modules.component('customImage', {
    templateUrl: '/app-portal/pages/shared/components/custom-image/customImage.html',
    controller: ['$rootScope', '$scope', 'MediaServices', function PortalTemplateController($rootScope, $scope, mediaServices) {
        var ctrl = this;
        ctrl.mediaFile = {
            file: null,
            fullPath: '',
            folder: 'Media',
            title: '',
            description: ''
        };
        ctrl.selectFile = function (file, errFiles) {

           
            if (file !== undefined && file !== null) {
                ctrl.mediaFile.folder = ctrl.folder ? ctrl.folder : 'Media';
                ctrl.mediaFile.title = ctrl.title ? ctrl.title : '';
                ctrl.mediaFile.description = ctrl.description ? ctrl.description : '';
                ctrl.mediaFile.file = file;
                if (ctrl.auto) {
                    ctrl.uploadFile();
                }
                else {
                    ctrl.getBase64(file);
                }
            }
        };

        ctrl.uploadFile = async function () {


            var resp = await mediaServices.uploadMedia(ctrl.mediaFile);
            if (resp.isSucceed) {
                ctrl.src = resp.data.fullPath;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        }
        ctrl.getBase64 = function (file) {
            if (file !== null) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function () {
                    var index = reader.result.indexOf(',') + 1;
                    var base64 = reader.result.substring(index);

                    ctrl.src = base64;
                    $scope.$apply();
                };
                reader.onerror = function (error) {
                    console.log(error);
                };
            }
            else {
                return null;
            }
        }
    }],
    bindings: {
        header: '=',
        title: '=',
        description: '=',
        src: '=',
        srcUrl: '=',
        type: '=',
        folder: '=',
        auto: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});