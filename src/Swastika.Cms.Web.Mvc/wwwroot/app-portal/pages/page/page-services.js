'use strict';
app.factory('PageServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var pagesServiceFactory = {};


    var _getPage = async function (id, type) {
        var apiUrl = '/api/' + $rootScope.settings.lang + '/page/';
        var url = apiUrl + 'details/' + type;
        if (id) {
            url += '/' + id;
        }
        var req = {
            method: 'GET',
            url: url
        };
        return await commonServices.getApiResult(req);
    };

    var _initPage = async function (type) {
        var apiUrl = '/api/' + $rootScope.settings.lang + '/page/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type
        };
        return await commonServices.getApiResult(req);
    };

    var _getPages = async function (request) {
        var apiUrl = '/api/' + $rootScope.settings.lang + '/page/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list/0',
            data: JSON.stringify(request)
        };
        
        return await commonServices.getApiResult(req);
    };

    var _removePage = async function (id) {
        var apiUrl = '/api/' + $rootScope.settings.lang + '/page/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req);
    };

    var _savePage = async function (page) {
        var apiUrl = '/api/' + $rootScope.settings.lang + '/page/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(page)
        };
        return await commonServices.getApiResult(req);
    };

    pagesServiceFactory.getPage = _getPage;
    pagesServiceFactory.initPage = _initPage;
    pagesServiceFactory.getPages = _getPages;
    pagesServiceFactory.removePage = _removePage;
    pagesServiceFactory.savePage = _savePage;
    return pagesServiceFactory;

}]);
