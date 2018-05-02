'use strict';
app.factory('ArticleServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var productsServiceFactory = {};

    var settings = commonServices.getSiteSettings();

    var _getArticle = async function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'GET',
            url: apiUrl + 'details/' + type + '/' + id
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _initArticle = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _getArticles = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _removeArticle = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'GET',
            url: apiUrl + 'remove/' + id
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _saveArticle = async function (article) {
        var apiUrl = '/api/' + settings.lang + '/article/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(article)
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    articlesServiceFactory.getArticle = _getArticle;
    articlesServiceFactory.initArticle = _initArticle;
    articlesServiceFactory.getArticles = _getArticles;
    articlesServiceFactory.removeArticle = _removeArticle;
    articlesServiceFactory.saveArticle = _saveArticle;
    return articlesServiceFactory;

}]);
