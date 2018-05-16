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

    var _initMedia = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/media/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
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

    mediasServiceFactory.getMedia = _getMedia;
    mediasServiceFactory.initMedia = _initMedia;
    mediasServiceFactory.getMedias = _getMedias;
    mediasServiceFactory.removeMedia = _removeMedia;
    mediasServiceFactory.saveMedia = _saveMedia;
    return mediasServiceFactory;

}]);
