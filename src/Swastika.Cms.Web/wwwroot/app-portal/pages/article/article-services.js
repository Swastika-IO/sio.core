'use strict';
app.factory('ArticleServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var articlesServiceFactory = {};

    var settings = $rootScope.settings

    var _getArticle = async function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/article/';
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

    var _initArticle = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };
        return await commonServices.getApiResult(req)
    };

    var _getArticles = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };
        
        return await commonServices.getApiResult(req);
    };

    var _removeArticle = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'GET',
            url: apiUrl + 'delete/' + id
        };
        return await commonServices.getApiResult(req)
    };

    var _saveArticle = async function (article) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(article)
        };
        return await commonServices.getApiResult(req)
    };

    articlesServiceFactory.getArticle = _getArticle;
    articlesServiceFactory.initArticle = _initArticle;
    articlesServiceFactory.getArticles = _getArticles;
    articlesServiceFactory.removeArticle = _removeArticle;
    articlesServiceFactory.saveArticle = _saveArticle;
    return articlesServiceFactory;

}]);
