
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
        ctrl.media = null;
        ctrl.selectFile = function (file, errFiles) {
            if (file !== undefined && file !== null) {
                ctrl.mediaFile.folder = ctrl.folder ? ctrl.folder : 'Media';
                ctrl.mediaFile.title = ctrl.title ? ctrl.title : '';
                ctrl.mediaFile.description = ctrl.description ? ctrl.description : '';
                ctrl.mediaFile.file = file;
                
                if (ctrl.auto) {
                    ctrl.uploadFile(file);
                }
                else {
                    ctrl.getBase64(file);
                }
            }
        };

        ctrl.uploadFile = async function (file) {
            if (file !== null) {
                $rootScope.isBusy = true;
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = async function () {
                    var getMedia = await mediaServices.getMedia(null, 'be');
                    if (getMedia.isSucceed) {
                        var index = reader.result.indexOf(',') + 1;
                        var base64 = reader.result.substring(index);
                        ctrl.mediaFile.fileName = file.name.substring(0, file.name.lastIndexOf('.'));
                        ctrl.mediaFile.extension = file.name.substring(file.name.lastIndexOf('.'));
                        ctrl.mediaFile.fileStream = reader.result;
                        var media = getMedia.data;
                        media.mediaFile = ctrl.mediaFile;
                        var resp = await mediaServices.saveMedia(media);
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
            if (file !== null && ctrl.postedFile) {
                $rootScope.isBusy = true;
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function () {
                    var index = reader.result.indexOf(',') + 1;
                    var base64 = reader.result.substring(index);
                    ctrl.postedFile.fileName = file.name.substring(0, file.name.lastIndexOf('.'));
                    ctrl.postedFile.extension = file.name.substring(file.name.lastIndexOf('.'));
                    ctrl.postedFile.fileStream = reader.result;
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
        header: '=',
        title: '=',
        description: '=',
        src: '=',
        srcUrl: '=',
        postedFile: '=',
        type: '=',
        folder: '=',
        auto: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});