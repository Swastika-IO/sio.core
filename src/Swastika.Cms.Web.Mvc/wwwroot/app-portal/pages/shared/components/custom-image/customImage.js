
modules.controller('ImageController', function PortalTemplateController($scope) {
    var ctrl = this;
    ctrl.selectFile = function (file, errFiles) {
        if (file !== undefined && file !== null) {
            console.log('asdfasdf', ctrl.auto)
            if (ctrl.auto) {
                var fileName = ctrl.uploadFile(file);
            }
            else {
                ctrl.getBase64(file);
            }
        }
    };

    ctrl.uploadFile = function (file) {
        // Create FormData object
        var files = new FormData();
        var folder = ctrl.folder;
        var title = ctrl.title;
        var description = ctrl.description;
        // Looping over all files and add it to FormData object
        files.append(file.name, file);

        // Adding one more key to FormData object
        files.append('fileFolder', folder);
        files.append('title', title);
        files.append('description', description);
        $.ajax({
            url: '/api/' + $rootScope.lang + '/media/upload', //'/api/tts/UploadImage',
            type: "POST",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: files,
            success: function (result) {
                ctrl.src = result.data.fullPath;
                $scope.$apply();
            },
            error: function (err) {
                return '';
            }
        });
        
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
});
modules.component('customImage', {
    templateUrl: '/app-portal/pages/shared/components/custom-image/customImage.html',
    controller: 'ImageController',
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