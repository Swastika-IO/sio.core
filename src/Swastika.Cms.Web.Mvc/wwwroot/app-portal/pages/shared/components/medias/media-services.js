'use strict';
app.factory('MediaServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var mediasServiceFactory = {};

    var settings = commonServices.getSettings();

    var _getMedia = async function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/media/';
        var url = apiUrl + 'details/' + type;
        if (id) {
            url += '/' + id;
        }
        var req = {
            method: 'GET',
            url: url
        };
        return await commonServices.getApiResult(req)
    };

    var _getMedias = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/media/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };
        
        return await commonServices.getApiResult(req);
    };

    var _removeMedia = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/media/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req)
    };

    var _saveMedia = async function (media) {
        var apiUrl = '/api/' + settings.lang + '/media/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(media)
        };
        return await commonServices.getApiResult(req)
    };

    var _uploadMedia = async function (mediaFile) {
        //var container = $(this).parents('.model-media').first().find('.custom-file').first();
        if (mediaFile.file !== undefined && mediaFile.file !== null) {
            // Create FormData object
            var files = new FormData();

            // Looping over all files and add it to FormData object
            files.append(mediaFile.file.name, mediaFile.file);

            // Adding one more key to FormData object
            files.append('fileFolder', mediaFile.folder);            files.append('title', mediaFile.title);
            files.append('description', mediaFile.description);

            var req = {
                url: '/api/' + settings.lang + '/media/upload', //'/api/tts/UploadImage',
                type: "POST",
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                data: files,
            };

            return await commonServices.getApiResult(req)
        }
    };

    mediasServiceFactory.getMedia = _getMedia;
    mediasServiceFactory.getMedias = _getMedias;
    mediasServiceFactory.removeMedia = _removeMedia;
    mediasServiceFactory.saveMedia = _saveMedia;
    mediasServiceFactory.uploadMedia = _uploadMedia;
    return mediasServiceFactory;

}]);
