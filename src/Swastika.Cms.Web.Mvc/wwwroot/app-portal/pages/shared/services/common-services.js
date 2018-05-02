'use strict';
app.factory('commonServices', ['$location', '$http', '$rootScope', 'authService', 'localStorageService', function ($location, $http, $rootScope, authService, localStorageService) {
    var adminCommonFactory = {};
    var _settings = {
        lang: '',
        cultures: []
    }
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

    var _getSiteSettings = async function () {
        return localStorageService.get('siteSettings');
    };

    var _setSiteSettings = async function (settings) {
        if (settings && settings.cultures.length > 0) {
            localStorageService.set('siteSettings', settings);
            window.top.location = location.href;
        }
    };

    var _fillSettings = async function () {
        if (!this._settings) {
            var req = {
                method: 'GET',
                url: 'api/portal/settings',
            };
            var resp = await this.getApiResult(req);
            if (resp.data.isSucceed) {
                _settings = resp.data.data;
                localStorageService.set('siteSettings', _settings);
                return _settings;
            }
        } else {
            return this._settings;
        }
    };
    var _getApiResult = async function (req) {
            $rootScope.isBusy = true;
            req.Authorization = authService.authentication.token;
            var headers = {
                'Content-Type': 'application/json',
                'RefreshToken': authService.authentication.refresh_token
            };
            req.headers = headers;
            return $http(req).then(function (results) {
                var resp = results.data;
                if (resp.data.responseKey === 'NotAuthorized') {
                    //Try again with new token from previous Request (optional)                
                    setTimeout(function () {
                        headers = {
                            'Content-Type': 'application/json',
                            'RefreshToken': authService.authentication.refresh_token
                        };
                        req.headers = headers;
                        return $http(req).then(function (results) {
                            if (resp.data.responseKey === 'NotAuthorized') {
                                authService.logOut();
                                $location.path('/admin/login');
                            }
                            else {
                                if (resp) {
                                    return resp.data;
                                }
                                else {
                                    return {
                                        isSucceed: false,
                                        data: null
                                    }
                                }
                            }
                        });
                    }, 2000);
                }
                else if (resp.data.authData !== null && resp.data.authData !== undefined) {
                    var authData = resp.data.authData;
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
                $rootScope.isBusy = false;
                return results;
            },
                function (error) {
                    $rootScope.isBusy = false;
                });
    };
    adminCommonFactory.getApiResult = _getApiResult;
    adminCommonFactory.getSiteSettings = _getSiteSettings;
    adminCommonFactory.setSiteSettings = _setSiteSettings;
    adminCommonFactory.showAlertMsg = _showAlertMsg;
    adminCommonFactory.checkfile = _checkfile;
    adminCommonFactory.fillSettings = _fillSettings;
    adminCommonFactory.settings = _settings;
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