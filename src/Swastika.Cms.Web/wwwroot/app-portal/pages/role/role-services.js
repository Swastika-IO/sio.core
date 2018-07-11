'use strict';
app.factory('RoleServices', ['$http', 'commonServices', function ($http, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var rolesServiceFactory = {};
    var apiUrl = '/api/role/';
    
    var _getRoles = function (request) {

        var req = {
            method: 'POST',
            url: apiUrl + 'list',
            data: request
        };

        return commonServices.getApiResult(req);
    };

    var _getRole = async function (id, viewType) {
        var apiUrl = '/api/role/';
        var url = apiUrl + 'details/' + viewType;
        if (id) {
            url += '/' + id;
        }
        var req = {
            method: 'GET',
            url: url
        };
        return await commonServices.getApiResult(req)
    };

    var _saveRole = async function (role) {
        var apiUrl = '/api/role/';
        var req = {
            method: 'POST',
            url: apiUrl + 'save',
            data: JSON.stringify(role)
        };
        return await commonServices.getApiResult(req)
    };

    var _removeRole = function (role) {
        var req = {
            method: 'POST',
            url: apiUrl + 'delete',
            data: JSON.stringify(role)
        };

        return commonServices.getApiResult(req);
    };

    var _createRole = function (name) {
        var req = {
            method: 'POST',
            url: apiUrl + 'create',
            data: JSON.stringify(name)
        };

        return commonServices.getApiResult(req);
    };

    rolesServiceFactory.getRoles = _getRoles;
    rolesServiceFactory.getRole = _getRole;
    rolesServiceFactory.saveRole = _saveRole;
    rolesServiceFactory.createRole = _createRole;
    rolesServiceFactory.removeRole = _removeRole;
    return rolesServiceFactory;

}]);
