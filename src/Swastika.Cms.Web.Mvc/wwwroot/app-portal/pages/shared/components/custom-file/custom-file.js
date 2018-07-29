
//modules.controller('ImageController', );
modules.component('customFile', {
    templateUrl: '/app-portal/pages/shared/components/custom-file/custom-file.html',
    controller: ['$rootScope', '$scope', 'MediaServices', function PortalTemplateController($rootScope, $scope, mediaServices) {
        var ctrl = this;        
        ctrl.media = null;
        ctrl.selectFile = function (file, errFiles) {
            if (file !== undefined && file !== null) {                
               
                    ctrl.getBase64(file);
               
            }
        };

        ctrl.uploadFile = async function (file) {
            if (file !== null) {
                $rootScope.isBusy = true;
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = async function () {
                    if (ctrl.media) {
                        var index = reader.result.indexOf(',') + 1;
                        var base64 = reader.result.substring(index);
                        ctrl.media.mediaFile.fileName = file.name.substring(0, file.name.lastIndexOf('.'));
                        ctrl.media.mediaFile.extension = file.name.substring(file.name.lastIndexOf('.'));
                        ctrl.media.mediaFile.fileStream = reader.result;
                        var resp = await mediaServices.saveMedia(ctrl.media);
                        if (resp && resp.isSucceed) {
                            ctrl.src = resp.data.fullPath;
                            $scope.$apply();
                        }
                        else {
                            if (resp) { $rootScope.showErrors(resp.errors); }
                            $scope.$apply();
                        }    
                    }
                    
                };
                reader.onerror = function (error) {

                };
            }
            else {
                return null;
            }
           
        }
        ctrl.getBase64 = function (file) {
            if (file !== null && ctrl.media.mediaFile) {
                $rootScope.isBusy = true;
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function () {
                    var index = reader.result.indexOf(',') + 1;
                    var base64 = reader.result.substring(index);
                    ctrl.media.mediaFile.fileName = file.name.substring(0, file.name.lastIndexOf('.'));
                    ctrl.media.mediaFile.extension = file.name.substring(file.name.lastIndexOf('.'));
                    ctrl.media.mediaFile.fileStream = reader.result;
                    ctrl.srcUrl = reader.result;
                    $rootScope.isBusy = false;
                    $scope.$apply();
                };
                reader.onerror = function (error) {

                };
            }
            else {
                return null;
            }
        }
        
    }],
    bindings: {
        media: '=',
        header: '=',
        folder: '=',
        auto: '=',        
        onDelete: '&',
        onUpdate: '&'
    }
});