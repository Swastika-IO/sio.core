'use strict';
app.controller('ImportFileController',
    ['$scope', '$rootScope', 'ImportFileServices', 'TranslatorService', 'SiteConfigurationService', 
        function ($scope, $rootScope, importFileServices, translatorService, siteConfigurationService) {

            $scope.importFile = {
                title: '',
                description: '',
                postedFile: {
                    file: null,
                    fullPath: '',
                    folderName: 'Import',
                    fileFolder: 'Import',
                    fileName: '',
                    extension: '',
                    content: '',
                    fileStream: ''
                }
            };
            $scope.importType = 'Language';
            $scope.types = [
                'Language',
                'Configuration'
            ];
            $scope.errors = [];
            $scope.saveImportFile = async function (importFile, importType) {
                $rootScope.isBusy = true;
                var resp = await importFileServices.saveImportFile(importFile.postedFile, importType);
                if (resp && resp.isSucceed) {
                    $scope.activedImportFile = resp.data;
                    $rootScope.showMessage('Success', 'success');
                    switch (importType) {
                        case 'Language':
                            translatorService.reset($rootScope.settings.lang).then(function () {
                                window.location.href = '/backend/language/list';
                            });
                            return false;
                        case 'Configuration':
                            siteConfigurationService.reset($rootScope.settings.lang).then(function () {
                                window.location.href = '/backend/configuration/list';
                            });
                            return false;
                    }


                }
                else {
                    if (resp) { $rootScope.showErrors(resp.errors); }
                    $rootScope.isBusy = false;
                    $scope.$apply();
                }
            };
        }]);
