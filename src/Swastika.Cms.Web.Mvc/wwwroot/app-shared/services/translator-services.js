'use strict';
app.factory('translatorService', ['$rootScope', 'commonServices', 'localStorageService', function ($rootScope, commonServices, localStorageService) {
    var factory = {};
    var _translator = null;

    var _init = function (translator) {
        this._translator = translator;
    }
    var _fillTranslator = async function (culture) {
        var translator = localStorageService.get('translator');
        if (translator) {
            _translator = translator;
            return translator;
        }
        else {
            translator = await commonServices.getTranslator(culture);
            localStorageService.set('translator', translator);
            return translator;
        }

    };
    var _getTranslator = async function (culture) {
        var url = 'api/portal';
        if (culture) {
            url += '/' + culture;
        }
        url += '/translator';
        var req = {
            method: 'GET',
            url: url
        };
        return commonServices.getApiResult(req).then(function (response) {
            if (response.isSucceed) {
                _translator = response.data;
                localStorageService.set('translator', _translator);
            }
            return _translator;
        });
    };
    var _reset = async function (lang) {

        await _getTranslator(lang);
    }
    var _get = function (keyword, defaultValue) {
        if (!_translator && $rootScope.settings) {
            _fillTranslator($rootScope.settings.lang).then(function (response) {
                _translator = response;
                return _translator[keyword] || defaultValue || getLinkCreateLanguage(keyword);
            });
        } else {
            return _translator[keyword] || defaultValue || getLinkCreateLanguage(keyword);
        }

    };

    var _getAsync = async function (keyword, defaultValue) {
        if (!_translator) {
            _translator = await _fillTranslator(lang);
            return _translator[keyword] || defaultValue || getLinkCreateLanguage(keyword);
        } else {
            return _translator[keyword] || defaultValue || getLinkCreateLanguage(keyword);
        }

    };

    var getLinkCreateLanguage = function (keyword) {
        //return '<span data-key="/backend/language/details?k=' + keyword + '">[' + keyword + ']</span>';
        return '[' + keyword + ']';
    }

    factory.getAsync = _getAsync;
    factory.get = _get;
    factory.init = _init;
    factory.reset = _reset;
    factory.translator = _translator;
    factory.fillTranslator = _fillTranslator;
    return factory;
}]);
