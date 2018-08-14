'use strict';
app.factory('translatorService', ['$rootScope', 'commonServices', 'localStorageService', function ($rootScope, commonServices, localStorageService) {
    var factory = {};
    var _translator = {
        lang: '',
        data: null
    };
    var _init = function (translator) {
        this._translator = translator;
    }
    var _fillTranslator = async function (culture) {
        
        if (this.translator.data && this.translator.lang == culture) {

            //_translator = translator;
            //this.translator = translator;
            
            return this.translator;
        }
        else {

            this.translator = await _getTranslator(culture);
            return this.translator;
        }

    };
    var _getTranslator = async function (culture) {
        var translator = localStorageService.get('translator');
        if (translator && translator.lang == culture) {
            translator = translator;
            return translator;
        }
        else {
            translator = { lang: culture, data: null };
            var url = 'api/portal';
            if (culture) {
                url += '/' + culture;
            }
            url += '/translator';
            var req = {
                method: 'GET',
                url: url
            };
            translator.lang = culture;
            var getData = await commonServices.getApiResult(req);
            if (getData.isSucceed) {
                translator.data = getData.data;
                localStorageService.set('translator', translator);
            }
            return translator;
        }
    };
    var _reset = async function (lang) {

        await _getTranslator(lang);
    }
    var _get = function (keyword, defaultValue) {
        if (!this.translator.data && $rootScope.settings) {
            $rootScope.isBusy = true;
            this.fillTranslator($rootScope.settings.lang).then(function (response) {
                $rootScope.isBusy = false;
                return response.data[keyword] || defaultValue || getLinkCreateLanguage(keyword);
            });
        } else {
            return this.translator.data[keyword] || defaultValue || getLinkCreateLanguage(keyword);
        }

    };

    var _getAsync = async function (keyword, defaultValue) {
        if (!this.translator.data && $rootScope.settings) {
            $rootScope.isBusy = true;
            this.translator = await _fillTranslator(lang);
            return this.translator.data[keyword] || defaultValue || getLinkCreateLanguage(keyword);
        } else {
            return this.translator.data[keyword] || defaultValue || getLinkCreateLanguage(keyword);
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
