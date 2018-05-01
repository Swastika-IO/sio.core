'use strict';
app.factory('ProductServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var productsServiceFactory = {};

    var settings = commonServices.getSiteSettings();

    var _getProduct = function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'GET',
            url: apiUrl + 'details/' + type + '/' + id
        };

        return commonServices.getApiResult(req);
    };

    var _initProduct = function (type) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };

        return commonServices.getApiResult(req);
    };

    var _getProducts = function (request) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };

        return commonServices.getApiResult(req);
    };

    var _removeProduct = function (id) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'GET',
            url: apiUrl + 'remove/' + id
        };

        return commonServices.getApiResult(req);
    };

    var _saveProduct = function (product) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(product)
        };

        return commonServices.getApiResult(req);
    };

    productsServiceFactory.getProduct = _getProduct;
    productsServiceFactory.initProduct = _initProduct;
    productsServiceFactory.getProducts = _getProducts;
    productsServiceFactory.removeProduct = _removeProduct;
    productsServiceFactory.saveProduct = _saveProduct;
    return productsServiceFactory;

}]);
