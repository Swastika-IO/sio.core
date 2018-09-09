'use strict';
app.factory('ThemeServices', ['$http', '$rootScope', 'CommonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var themesServiceFactory = {};

    var settings = $rootScope.settings;

    var _getTheme = async function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/theme/';
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

    var _syncTemplates = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/theme/';
        var url = apiUrl + 'sync/' + id;        
        var req = {
            method: 'GET',
            url: url
        };
        return await commonServices.getApiResult(req,'');
    };

    var _initTheme = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/theme/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };
        return await commonServices.getApiResult(req)
    };

    var _getThemes = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/theme/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };
        
        return await commonServices.getApiResult(req);
    };

    var _removeTheme = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/theme/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req)
    };

    var _saveTheme = async function (theme) {
        var apiUrl = '/api/' + $rootScope.settings.lang + '/theme/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(theme)
        };
        return await commonServices.getApiResult(req);
    };

    themesServiceFactory.syncTemplates = _syncTemplates;
    themesServiceFactory.getTheme = _getTheme;
    themesServiceFactory.initTheme = _initTheme;
    themesServiceFactory.getThemes = _getThemes;
    themesServiceFactory.removeTheme = _removeTheme;
    themesServiceFactory.saveTheme = _saveTheme;
    return themesServiceFactory;

}]);
