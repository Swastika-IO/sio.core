'use strict';
app.factory('userServices', ['$http', 'CommonServices', function ($http, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var usersServiceFactory = {};
    var apiUrl = '/api/e-voucher/';
    var _getUserDemographicInfo = function () {
        var url = '/api/GetUserDemographicInfo';
        var req = {
            method: 'GET',
            url: serviceBase + url
        };

        return commonServices.getApiResult(req);
    };
    var _importUsers = function (strBase64) {
        var url = 'import-users';
        var req = {
            method: 'POST',
            url: apiUrl + url,
            data: JSON.stringify({ strBase64: strBase64 })
        };

        return commonServices.getApiResult(req);
    };

    var _getUsers = function (request) {
        
        var req = {
            method: 'POST',
            url: apiUrl + 'users',
            data: request
        };

        return commonServices.getApiResult(req);
    };
    var _updateRoleStatus = function (userInRole) {

        var req = {
            method: 'POST',
            url: serviceBase + '/api/roles/UpdateUserRole',
            data: JSON.stringify(userInRole)

        };

        return commonServices.getApiResult(req);
    };

    var _removeUser = function (user) {
        var req = {
            method: 'POST',
            url: apiUrl + 'remove-user',
            data: JSON.stringify(user)
        };

        return commonServices.getApiResult(req);
    };

    usersServiceFactory.importUsers = _importUsers;
    usersServiceFactory.getUsers = _getUsers;
    usersServiceFactory.removeUser = _removeUser;
    usersServiceFactory.updateRoleStatus = _updateRoleStatus;
    usersServiceFactory.getUserDemographicInfo = _getUserDemographicInfo;
    return usersServiceFactory;

}]);
