'use strict';
app.factory('ModuleServices', ['$http', '$rootScope', 'CommonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var modulesServiceFactory = {};

    var settings = $rootScope.settings

    var _getModule = async function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/module/';
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

    var _initModule = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/module/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };
        return await commonServices.getApiResult(req)
    };

    var _getModules = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/module/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };
        
        return await commonServices.getApiResult(req);
    };

    var _removeModule = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/module/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req)
    };

    var _saveModule = async function (module) {
        var apiUrl = '/api/' + settings.lang + '/module/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(module)
        };
        return await commonServices.getApiResult(req)
    };

    modulesServiceFactory.getModule = _getModule;
    modulesServiceFactory.initModule = _initModule;
    modulesServiceFactory.getModules = _getModules;
    modulesServiceFactory.removeModule = _removeModule;
    modulesServiceFactory.saveModule = _saveModule;
    return modulesServiceFactory;

}]);
