'use strict';
app.factory('TemplateServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var templateServiceFactory = {};

    var settings = commonServices.getSettings();

    var _getTemplate = async function (themeId, id, type) {
        var apiUrl = '/api/' + settings.lang + '/template/details/' + type + '/' + themeId;
        if (id) {
            apiUrl += '/' + id;
        }
        var req = {
            method: 'GET',
            url: apiUrl
        };
        return await commonServices.getApiResult(req)
    };


    var _getTemplates = async function (request, folderType) {
        var apiUrl = '/api/' + settings.lang + '/template/list';
        if (folderType) {
            apiUrl += '/' + folderType;
        }
        var req = {
            method: 'POST',
            url: apiUrl,
            data: JSON.stringify(request)
        };

        return await commonServices.getApiResult(req);
    };

    var _initModuleForm = async function (name) {
        var apiUrl = '/api/' + settings.lang + '/template/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + name,
        };

        return await commonServices.getApiResult(req);
    };

    var _removeTemplate = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/template/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req)
    };

    var _saveTemplate = async function (template) {
        var apiUrl = '/api/' + settings.lang + '/template/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(template)
        };
        return await commonServices.getApiResult(req)
    };

    templateServiceFactory.getTemplate = _getTemplate;
    templateServiceFactory.getTemplates = _getTemplates;
    templateServiceFactory.removeTemplate = _removeTemplate;
    templateServiceFactory.saveTemplate = _saveTemplate;
    templateServiceFactory.initModuleForm = _initModuleForm;
    return templateServiceFactory;
}]);
