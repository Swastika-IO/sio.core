'use strict';
app.factory('ModuleDataServicesbk', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var moduleDatasServiceFactory = {};

    var settings = commonServices.getSettings();

    var _getModuleData = async function (moduleId, id, type) {
        var apiUrl = '/api/' + settings.lang + '/module-data/';
        var url = apiUrl + 'details/' + type;
        if (id) {
            url += +'/' + moduleId + '/' + id;
        } else {
            url += +'/' + moduleId;
        }
        var req = {
            method: 'GET',
            url: url
        };
        return await commonServices.getApiResult(req)
    };

    var _initModuleData = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/module-data/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };
        return await commonServices.getApiResult(req)
    };

    var _getModuleDatas = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/module-data/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };

        return await commonServices.getApiResult(req);
    };

    var _removeModuleData = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/module-data/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req)
    };

    var _saveModuleData = async function (moduleData) {
        var apiUrl = '/api/' + settings.lang + '/module-data/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(moduleData)
        };
        return await commonServices.getApiResult(req)
    };

    moduleDatasServiceFactory.getModuleData = _getModuleData;
    moduleDatasServiceFactory.initModuleData = _initModuleData;
    moduleDatasServiceFactory.getModuleDatas = _getModuleDatas;
    moduleDatasServiceFactory.removeModuleData = _removeModuleData;
    moduleDatasServiceFactory.saveModuleData = _saveModuleData;
    return moduleDatasServiceFactory;

}]);
