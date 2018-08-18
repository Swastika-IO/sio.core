'use strict';
app.factory('commonServices', ['$location', '$http', '$rootScope', 'localStorageService', function ($location, $http, $rootScope, localStorageService) {
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

    var _getSettings = async function () {
        var url = '/api/portal';
        url += '/init-settings';
        var req = {
            method: 'GET',
            url: url
        };
        return _getApiResult(req);
    };

    var _setSettings = async function (settings) {
        if (settings && settings.cultures.length > 0) {
            localStorageService.set('settings', settings);
            window.top.location = location.href;
        }
    };

    var _removeSettings = async function (settings) {
        localStorageService.remove('settings');
    };

    var _fillSettings = async function (culture) {
        var settings = localStorageService.get('settings');
        if (settings) {
            _settings = settings;
            return settings;
        }
        else {
            settings = await _getSettings(culture);
            localStorageService.set('settings', settings);
            return settings;
        }

    };
    var _getApiResult = async function (req) {
        $rootScope.isBusy = true;

        return $http(req).then(function (resp) {
            //var resp = results.data;
            $rootScope.isBusy = false;
            return resp.data;
        },
            function (error) {
                var t = { isSucceed: false, errors: [error.statusText] };
                $rootScope.isBusy = false;
                return t;
            });
    };
    adminCommonFactory.getApiResult = _getApiResult;
    adminCommonFactory.getSettings = _getSettings;
    adminCommonFactory.setSettings = _setSettings;
    adminCommonFactory.removeSettings = _removeSettings;
    adminCommonFactory.showAlertMsg = _showAlertMsg;
    adminCommonFactory.checkfile = _checkfile;
    adminCommonFactory.fillSettings = _fillSettings;
    adminCommonFactory.settings = _settings;
    return adminCommonFactory;

}]);
