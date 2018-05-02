'use strict';
app.factory('ProductServices', ['$http', '$rootScope', 'commonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var productsServiceFactory = {};

    var settings = commonServices.getSiteSettings();

    var _getProduct = async function (id, type) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'GET',
            url: apiUrl + 'details/' + type + '/' + id
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _initProduct = async function (type) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'GET',
            url: apiUrl + 'init/' + type,
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _getProducts = async function (request) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: JSON.stringify(request)
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _removeProduct = async function (id) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'GET',
            url: apiUrl + 'remove/' + id
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    var _saveProduct = async function (product) {
        var apiUrl = '/api/' + settings.lang + '/product/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(product)
        };
        var resp = await commonServices.getApiResult(req)
        return resp.data;
    };

    productsServiceFactory.getProduct = _getProduct;
    productsServiceFactory.initProduct = _initProduct;
    productsServiceFactory.getProducts = _getProducts;
    productsServiceFactory.removeProduct = _removeProduct;
    productsServiceFactory.saveProduct = _saveProduct;
    return productsServiceFactory;

}]);
