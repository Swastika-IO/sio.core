'use strict';
app.factory('ImportFileServices', ['$http', '$rootScope', 'CommonServices', function ($http, $rootScope, commonServices) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';

    var importFilesServiceFactory = {};

    var settings = $rootScope.settings;

    var _saveImportFile = async function (importFile, type) {
        var apiUrl = '/api/portal/import/' + type;
        var req = {
            method: 'POST',
            url: apiUrl,
            data: JSON.stringify(importFile)
        };
        return await commonServices.getApiResult(req);
    };

    importFilesServiceFactory.saveImportFile = _saveImportFile;
    return importFilesServiceFactory;

}]);
