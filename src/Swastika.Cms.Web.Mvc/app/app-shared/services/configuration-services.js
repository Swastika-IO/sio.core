'use strict';
app.factory('SiteConfigurationService', ['$rootScope', 'CommonServices', 'localStorageService', function ($rootScope, commonServices, localStorageService) {
    var factory = {};
    var _configurations = {
        lang: '',
        data: null
    };
    var _fillConfigurations = async function (culture) {

        if (this.configurations.data && this.configurations.lang === culture) {

            //_configurations = configurations;
            //this.configurations = configurations;

            return this.configurations;
        }
        else {

            this.configurations = await _getConfigurations(culture);
            return this.configurations;
        }

    };
    var _getConfigurations = async function (culture) {
        var configurations = localStorageService.get('configurations');
        if (configurations && configurations.lang === culture) {
            configurations = configurations;
            return configurations;
        }
        else {
            configurations = { lang: culture, data: null };
            var url = '/api/portal';
            if (culture) {
                url += '/' + culture;
            }
            url += '/configurations';
            var req = {
                method: 'GET',
                url: url
            };
            configurations.lang = culture;
            var getData = await commonServices.getApiResult(req);
            if (getData.isSucceed) {
                configurations.data = getData.data;
                localStorageService.set('configurations', configurations);
            }
            return configurations;
        }
    };
    var _reset = async function (lang) {
        localStorageService.remove('configurations');
        await _getConfigurations(lang);
    };
    var _get = function (keyword, isWrap, defaultText) {
        if (!this.configurations.data && $rootScope.settings) {
            $rootScope.isBusy = true;
            this.fillConfigurations($rootScope.settings.lang).then(function (response) {
                $rootScope.isBusy = false;
                return response.data[keyword] || defaultText || getLinkCreateLanguage(keyword, isWrap);
            });
        } else {
            return this.configurations.data[keyword] || defaultText || getLinkCreateLanguage(keyword, isWrap);
        }

    };

    var _getAsync = async function (keyword, defaultText) {
        if (!this.configurations.data && $rootScope.settings) {
            $rootScope.isBusy = true;
            this.configurations = await _fillConfigurations(lang);
            return this.configurations.data[keyword] || defaultText || getLinkCreateLanguage(keyword, isWrap);
        } else {
            return this.configurations.data[keyword] || defaultText || getLinkCreateLanguage(keyword, isWrap);
        }

    };

    var getLinkCreateLanguage = function (keyword, isWrap) {
        //return '<span data-key="/backend/language/details?k=' + keyword + '">[' + keyword + ']</span>';
        return isWrap ? '[' + keyword + ']' : keyword;
    };

    factory.getAsync = _getAsync;
    factory.get = _get;
    factory.reset = _reset;
    factory.configurations = _configurations;
    factory.fillConfigurations = _fillConfigurations;
    return factory;
}]);
