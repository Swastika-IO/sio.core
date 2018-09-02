'use strict';
app.factory('AuthService', ['$http', '$rootScope', '$location', '$q', 'localStorageService', 'ngAuthSettings',
    function ($http, $rootScope, $location, $q, localStorageService, ngAuthSettings) {

        var authServiceFactory = {};

        var _authentication = {
            isAuth: false,
            userName: "",
            userId: '',
            token: '',
            useRefreshTokens: false,
            avatar: "",
            referredUrl: '/'
        };

        var _externalAuthData = {
            provider: "",
            userName: "",
            externalAccessToken: ""
        };

        var _saveRegistration = function (registration) {

            _logOut();

            return $http.post(ngAuthSettings.serviceBase + '/api/account/register', registration).then(function (response) {
                return response;
            });

        };

        var _loginbk = function (loginData) {
            var data = {
                UserName: loginData.username,
                Password: loginData.password,
                RememberMe: loginData.rememberme,
                Email: '',
                ReturnUrl: '',
            };
            var deferred = $q.defer();

            $http.post(ngAuthSettings.serviceBase + '/api/account/login', JSON.stringify(data)).then(function (response) {
                var data = response.data.data;
                localStorageService.set('authorizationData',
                    {
                        userRoles: data.userData.userRoles,
                        token: data.access_token, userName: data.userData.firstName, roleNames: data.userData.roles,
                        avatar: data.userData.avatar, refresh_token: data.refresh_token, userId: data.userData.id
                    });
                _authentication.isAuth = true;
                angular.forEach(data.userData.userRoles, function (value, key) {
                    if (value.role.name === 'SuperAdmin'
                        //|| value.role.name === 'Admin'
                    ) {
                        _authentication.isAdmin = true;
                    }
                });
                //_authentication.isAdmin = $.inArray("SuperAdmin", data.userData.roles) >= 0;
                //_authentication.userName = data.userData.NickName;
                _authentication.roleNames = data.userData.roles;
                _authentication.userId = data.userData.id;
                _authentication.avatar = data.userData.avatar;
                _authentication.useRefreshTokens = loginData.rememberme;
                _authentication.token = data.access_token;
                _authentication.refresh_token = data.refresh_token;
                deferred.resolve(response);

            }, function (error) {
                _logOut();
                deferred.reject(error);
            });
            return deferred.promise;
        };

        var _login = async function (loginData) {
            var data = {
                UserName: loginData.username,
                Password: loginData.password,
                RememberMe: loginData.rememberme,
                Email: '',
                ReturnUrl: '',
            };
            var apiUrl = ngAuthSettings.serviceBase + '/api/account/login';
            var req = {
                method: 'POST',
                url: apiUrl,
                data: JSON.stringify(data)
            };
            var resp = await _getApiResult(req);

            if (resp.isSucceed) {
                data = resp.data;
                localStorageService.set('authorizationData',
                    {
                        userRoles: data.userData.userRoles,
                        token: data.access_token, userName: data.userData.firstName, roleNames: data.userData.roles,
                        avatar: data.userData.avatar, refresh_token: data.refresh_token, userId: data.userData.id
                    });
                _authentication.isAuth = false;
                angular.forEach(data.userData.userRoles, function (value, key) {
                    if (value.role.name === 'SuperAdmin'
                        //|| value.role.name === 'Admin'
                    ) {
                        _authentication.isAdmin = true;
                    }
                });
                _authentication.isAdmin = $.inArray("SuperAdmin", data.userData.roles) >= 0;
                _authentication.userName = data.userData.NickName;
                _authentication.roleNames = data.userData.roles;
                _authentication.userId = data.userData.id;
                _authentication.avatar = data.userData.avatar;
                _authentication.useRefreshTokens = loginData.rememberme;
                _authentication.token = data.access_token;
                _authentication.refresh_token = data.refresh_token;
                _fillSettings().then(function (response) {
                    window.location.href = document.referrer || '/';//_authentication.referredUrl;
                });

            } else {
                $rootScope.isBusy = false;
                $rootScope.showErrors(resp.errors);
            }
            return resp;
        };


        var _logOut = function () {

            localStorageService.remove('authorizationData');

            _authentication.isAuth = false;
            _authentication.isAdmin = false;
            _authentication.userName = "";
            _authentication.useRefreshTokens = false;
            _authentication.token = null;
            _authentication.refresh_token = null;

        };

        var _fillAuthData = async function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                angular.forEach(authData.userRoles, function (value, key) {
                    if (value.role.name === 'SuperAdmin'
                        //|| value.role.name === 'Admin'
                    ) {
                        _authentication.isAdmin = true;
                    }
                });
                //_authentication.isAdmin = $.inArray("SuperAdmin", authData.roleNames) >= 0;
                _authentication.userName = authData.userName;
                _authentication.roleNames = authData.roleNames;
                _authentication.userId = authData.userId;
                _authentication.avatar = authData.avatar;

                _authentication.token = authData.token;
                _authentication.refresh_token = authData.refresh_token;
            }

        };

        var _getSettings = async function (culture) {
            var settings = localStorageService.get('settings');
            // && culture !== undefined && settings.lang === culture
            if (settings) {
                return settings;
            }
            else {
                var url = '/api/portal';
                if (culture) {
                    url += '/' + culture;
                }
                url += '/settings';
                var req = {
                    method: 'GET',
                    url: url
                };
                return _getApiResult(req).then(function (response) {
                    return response.data;
                });
            }
        };

        var _fillSettings = async function (culture) {
            var settings = localStorageService.get('settings');
            if (settings && settings.lang === culture) {
                _settings = settings;
                return settings;
            }
            else {
                if (culture !== undefined && settings && settings.lang !== culture) {
                    await _removeSettings();
                    await _removeTranslator();
                }
                settings = await _getSettings(culture);
                localStorageService.set('settings', settings);
                //window.top.location = location.href;
                return settings;
            }

        };

        var _refreshToken = function (id) {
            var deferred = $q.defer();

            $http.get(ngAuthSettings.serviceBase + '/api/account/refresh-token/' + id).then(function (response) {
                var data = response.data.data;

                if (data) {
                    var authData = localStorageService.get('authorizationData');
                    authData.token = data.access_token;
                    authData.refresh_token = data.refresh_token;
                    _authentication.token = data.access_token;
                    _authentication.refresh_token = data.refresh_token;
                    localStorageService.set('authorizationData', authData);
                }

                deferred.resolve(response);

            }, function (error) {
                _logOut();
                deferred.reject(error);
            });
            return deferred.promise;
        };


        var _obtainAccessToken = function (externalData) {

            var deferred = $q.defer();

            $http.get(ngAuthSettings.serviceBase + '/api/account/ObtainLocalAccessToken', { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } }).success(function (response) {

                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, roleName: response.userData.roleNames, refresh_token: response.refresh_token, useRefreshTokens: true });

                _authentication.isAuth = true;
                _authentication.isAdmin = _authentication.isAdmin = $.inArray("SuperAdmin", response.userData.RoleNames) >= 0;
                _authentication.userName = response.userName;
                _authentication.useRefreshTokens = false;

                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var _registerExternal = function (registerExternalData) {

            var deferred = $q.defer();

            $http.post(ngAuthSettings.serviceBase + '/api/account/registerexternal', registerExternalData).success(function (response) {

                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refresh_token: response.refresh_token, useRefreshTokens: true });

                _authentication.isAuth = true;
                _authentication.userName = response.userName;
                _authentication.useRefreshTokens = false;

                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var _getApiResult = async function (req) {
            $rootScope.isBusy = true;

            return $http(req).then(function (resp) {
                //var resp = results.data;

                return resp.data;
            },
                function (error) {
                    var t = { isSucceed: false, errors: [error.statusText] };
                    return t;
                });
        };

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;
        authServiceFactory.refreshToken = _refreshToken;

        authServiceFactory.obtainAccessToken = _obtainAccessToken;
        authServiceFactory.externalAuthData = _externalAuthData;
        authServiceFactory.registerExternal = _registerExternal;

        return authServiceFactory;
    }]);