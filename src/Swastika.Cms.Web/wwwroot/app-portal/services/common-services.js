'use strict';
app.factory('commonServices', ['$location', '$http', '$rootScope', 'authService', 'localStorageService', function ($location, $http, $rootScope, authService, localStorageService) {
    var adminCommonFactory = {};

    var _showAlertMsg = function (title, message) {
        $rootScope.message = {
            title: title,
            value: message
        };
        $('#modal-msg').modal('show');
    };

    var _checkfile = function (sender, validExts) {
        var fileExt = sender.value;
        fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
        if (validExts.indexOf(fileExt) < 0) {
            _showAlertMsg("", "Invalid file selected, valid files are of " + validExts.toString() + " types.");
            sender.value = "";
            return false;
        }
        else return true;
    };

    var _getApiResult = function (req) {
        req.Authorization = authService.authentication.token;
        var headers = {
            'Content-Type': 'application/json',
            'RefreshToken': authService.authentication.refresh_token
        };
        req.headers = headers;
        return $http(req).then(function (results) {
            if (results.data.responseKey === 'NotAuthorized') {
                //Try again with new token from previous Request (optional)                
                setTimeout(function () {
                    headers = {
                        'Content-Type': 'application/json',
                        'RefreshToken': authService.authentication.refresh_token
                    };
                    req.headers = headers;
                    return $http(req).then(function (results) {
                        if (results.data.responseKey === 'NotAuthorized') {
                            authService.logOut();
                            $location.path('/admin/login');
                        }
                        else {
                            if (results) {
                                return results.data;
                            }
                            else {
                                return {
                                    isSucceed : false,
                                    data : null
                                }
                            }
                        }
                    });
                }, 2000);
            }
            else if (results.data.authData !== null && results.data.authData !== undefined) {
                var authData = results.data.authData;
                localStorageService.set('authorizationData', { token: authData.access_token, userName: authData.userData.NickName, roleNames: authData.userData.RoleNames, avatar: authData.userData.Avatar, refresh_token: authData.refresh_token, userId: authData.userData.Id });
                authService.authentication.isAuth = true;
                authService.authentication.isAdmin = $.inArray("Admin", authData.userData.RoleNames) >= 0;
                authService.authentication.userName = authData.userData.NickName;
                authService.authentication.roleNames = authData.userData.RoleNames;
                authService.authentication.userId = authData.userData.Id;
                authService.authentication.avatar = authData.userData.Avatar;
                authService.authentication.token = authData.access_token;
                authService.authentication.refresh_token = authData.refresh_token;
            }
            return results;
        },
            function () {
            });
    };
    adminCommonFactory.getApiResult = _getApiResult;
    adminCommonFactory.showAlertMsg = _showAlertMsg;
    adminCommonFactory.checkfile = _checkfile;
    return adminCommonFactory;

}]);

$(document).ready(function () {

    // check all for list
    $('.chkSelectAll').change(function () {
        if ($(this).is(":checked")) {
            $('.chkSelect').attr('checked', 'checked');
        }
        else {
            $('.chkSelect').removeAttr('checked');
        }
    });

});