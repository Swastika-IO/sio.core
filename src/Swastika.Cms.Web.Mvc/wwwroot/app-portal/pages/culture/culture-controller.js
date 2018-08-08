'use strict';
app.controller('CultureController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'CultureServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, cultureServices) {
        $scope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'Priority',
            direction: '0',
            fromDate: null,
            toDate: null,
            keyword: ''
        };
        $scope.cultures=  [
            { specificulture: 'en-us', fullName: 'English', icon: 'flag-icon-us' },
            { specificulture: 'af', fullName: 'Afrikaans', icon: 'flag-icon-af'  },
            { specificulture: 'af-ZA', fullName: 'Afrikaans (South Africa)', icon: 'flag-icon-af'  },
            { specificulture: 'ar', fullName: 'Arabic', icon: 'flag-icon-ar' },
            { specificulture: 'ar-AE', fullName: 'Arabic (U.A.E.)', icon: 'flag-icon-ar' },
            { specificulture: 'ar-BH', fullName: 'Arabic (Bahrain)' },
            { specificulture: 'ar-DZ', fullName: 'Arabic (Algeria)' },
            { specificulture: 'ar-EG', fullName: 'Arabic (Egypt)' },
            { specificulture: 'ar-IQ', fullName: 'Arabic (Iraq)' },
            { specificulture: 'ar-JO', fullName: 'Arabic (Jordan)' },
            { specificulture: 'ar-KW', fullName: 'Arabic (Kuwait)' },
            { specificulture: 'ar-LB', fullName: 'Arabic (Lebanon)' },
            { specificulture: 'ar-LY', fullName: 'Arabic (Libya)' },
            { specificulture: 'ar-MA', fullName: 'Arabic (Morocco)' },
            { specificulture: 'ar-OM', fullName: 'Arabic (Oman)' },
            { specificulture: 'ar-QA', fullName: 'Arabic (Qatar)' },
            { specificulture: 'ar-SA', fullName: 'Arabic (Saudi Arabia)' },
            { specificulture: 'ar-SY', fullName: 'Arabic (Syria)' },
            { specificulture: 'ar-TN', fullName: 'Arabic (Tunisia)' },
            { specificulture: 'ar-YE', fullName: 'Arabic (Yemen)' },
            { specificulture: 'az', fullName: 'Azeri (Latin)' },
            { specificulture: 'az-AZ', fullName: 'Azeri (Latin) (Azerbaijan)' },
            { specificulture: 'az-AZ', fullName: 'Azeri (Cyrillic) (Azerbaijan)' },
            { specificulture: 'be', fullName: 'Belarusian' },
            { specificulture: 'be-BY', fullName: 'Belarusian (Belarus)' },
            { specificulture: 'bg', fullName: 'Bulgarian' },
            { specificulture: 'bg-BG', fullName: 'Bulgarian (Bulgaria)' },
            { specificulture: 'bs-BA', fullName: 'Bosnian (Bosnia and Herzegovina)' },
            { specificulture: 'ca', fullName: 'Catalan' },
            { specificulture: 'ca-ES', fullName: 'Catalan (Spain)' },
            { specificulture: 'cs', fullName: 'Czech' },
            { specificulture: 'cs-CZ', fullName: 'Czech (Czech Republic)' },
            { specificulture: 'cy', fullName: 'Welsh' },
            { specificulture: 'cy-GB', fullName: 'Welsh (United Kingdom)' },
            { specificulture: 'da', fullName: 'Danish' },
            { specificulture: 'da-DK', fullName: 'Danish (Denmark)' },
            { specificulture: 'de', fullName: 'German' },
            { specificulture: 'de-AT', fullName: 'German (Austria)' },
            { specificulture: 'de-CH', fullName: 'German (Switzerland)' },
            { specificulture: 'de-DE', fullName: 'German (Germany)' },
            { specificulture: 'de-LI', fullName: 'German (Liechtenstein)' },
            { specificulture: 'de-LU', fullName: 'German (Luxembourg)' },
            { specificulture: 'dv', fullName: 'Divehi' },
            { specificulture: 'dv-MV', fullName: 'Divehi (Maldives)' },
            { specificulture: 'el', fullName: 'Greek' },
            { specificulture: 'el-GR', fullName: 'Greek (Greece)' },
            { specificulture: 'en', fullName: 'English' },
            { specificulture: 'en-AU', fullName: 'English (Australia)', icon: 'flag-icon-au' },
            { specificulture: 'en-BZ', fullName: 'English (Belize)', icon: 'flag-icon-bz' },
            { specificulture: 'en-CA', fullName: 'English (Canada)' },
            { specificulture: 'en-CB', fullName: 'English (Caribbean)' },
            { specificulture: 'en-GB', fullName: 'English (United Kingdom)' },
            { specificulture: 'en-IE', fullName: 'English (Ireland)' },
            { specificulture: 'en-JM', fullName: 'English (Jamaica)' },
            { specificulture: 'en-NZ', fullName: 'English (New Zealand)' },
            { specificulture: 'en-PH', fullName: 'English (Republic of the Philippines)' },
            { specificulture: 'en-TT', fullName: 'English (Trinidad and Tobago)' },
            { specificulture: 'en-US', fullName: 'English (United States)' },
            { specificulture: 'en-ZA', fullName: 'English (South Africa)' },
            { specificulture: 'en-ZW', fullName: 'English (Zimbabwe)' },
            { specificulture: 'eo', fullName: 'Esperanto' },
            { specificulture: 'es', fullName: 'Spanish' },
            { specificulture: 'es-AR', fullName: 'Spanish (Argentina)' },
            { specificulture: 'es-BO', fullName: 'Spanish (Bolivia)' },
            { specificulture: 'es-CL', fullName: 'Spanish (Chile)' },
            { specificulture: 'es-CO', fullName: 'Spanish (Colombia)' },
            { specificulture: 'es-CR', fullName: 'Spanish (Costa Rica)' },
            { specificulture: 'es-DO', fullName: 'Spanish (Dominican Republic)' },
            { specificulture: 'es-EC', fullName: 'Spanish (Ecuador)' },
            { specificulture: 'es-ES', fullName: 'Spanish (Castilian)' },
            { specificulture: 'es-ES', fullName: 'Spanish (Spain)' },
            { specificulture: 'es-GT', fullName: 'Spanish (Guatemala)' },
            { specificulture: 'es-HN', fullName: 'Spanish (Honduras)' },
            { specificulture: 'es-MX', fullName: 'Spanish (Mexico)' },
            { specificulture: 'es-NI', fullName: 'Spanish (Nicaragua)' },
            { specificulture: 'es-PA', fullName: 'Spanish (Panama)' },
            { specificulture: 'es-PE', fullName: 'Spanish (Peru)' },
            { specificulture: 'es-PR', fullName: 'Spanish (Puerto Rico)' },
            { specificulture: 'es-PY', fullName: 'Spanish (Paraguay)' },
            { specificulture: 'es-SV', fullName: 'Spanish (El Salvador)' },
            { specificulture: 'es-UY', fullName: 'Spanish (Uruguay)' },
            { specificulture: 'es-VE', fullName: 'Spanish (Venezuela)' },
            { specificulture: 'et', fullName: 'Estonian' },
            { specificulture: 'et-EE', fullName: 'Estonian (Estonia)' },
            { specificulture: 'eu', fullName: 'Basque' },
            { specificulture: 'eu-ES', fullName: 'Basque (Spain)' },
            { specificulture: 'fa', fullName: 'Farsi' },
            { specificulture: 'fa-IR', fullName: 'Farsi (Iran)' },
            { specificulture: 'fi', fullName: 'Finnish' },
            { specificulture: 'fi-FI', fullName: 'Finnish (Finland)' },
            { specificulture: 'fo', fullName: 'Faroese' },
            { specificulture: 'fo-FO', fullName: 'Faroese (Faroe Islands)' },
            { specificulture: 'fr', fullName: 'French' },
            { specificulture: 'fr-BE', fullName: 'French (Belgium)' },
            { specificulture: 'fr-CA', fullName: 'French (Canada)' },
            { specificulture: 'fr-CH', fullName: 'French (Switzerland)' },
            { specificulture: 'fr-FR', fullName: 'French (France)', icon: 'flag-icon-fr' },
            { specificulture: 'fr-LU', fullName: 'French (Luxembourg)' },
            { specificulture: 'fr-MC', fullName: 'French (Principality of Monaco)' },
            { specificulture: 'gl', fullName: 'Galician' },
            { specificulture: 'gl-ES', fullName: 'Galician (Spain)' },
            { specificulture: 'gu', fullName: 'Gujarati' },
            { specificulture: 'gu-IN', fullName: 'Gujarati (India)' },
            { specificulture: 'he', fullName: 'Hebrew' },
            { specificulture: 'he-IL', fullName: 'Hebrew (Israel)' },
            { specificulture: 'hi', fullName: 'Hindi' },
            { specificulture: 'hi-IN', fullName: 'Hindi (India)' },
            { specificulture: 'hr', fullName: 'Croatian' },
            { specificulture: 'hr-BA', fullName: 'Croatian (Bosnia and Herzegovina)' },
            { specificulture: 'hr-HR', fullName: 'Croatian (Croatia)' },
            { specificulture: 'hu', fullName: 'Hungarian' },
            { specificulture: 'hu-HU', fullName: 'Hungarian (Hungary)' },
            { specificulture: 'hy', fullName: 'Armenian' },
            { specificulture: 'hy-AM', fullName: 'Armenian (Armenia)' },
            { specificulture: 'id', fullName: 'Indonesian' },
            { specificulture: 'id-ID', fullName: 'Indonesian (Indonesia)' },
            { specificulture: 'is', fullName: 'Icelandic' },
            { specificulture: 'is-IS', fullName: 'Icelandic (Iceland)' },
            { specificulture: 'it', fullName: 'Italian' },
            { specificulture: 'it-CH', fullName: 'Italian (Switzerland)' },
            { specificulture: 'it-IT', fullName: 'Italian (Italy)' },
            { specificulture: 'ja', fullName: 'Japanese' },
            { specificulture: 'ja-JP', fullName: 'Japanese (Japan)' },
            { specificulture: 'ka', fullName: 'Georgian' },
            { specificulture: 'ka-GE', fullName: 'Georgian (Georgia)' },
            { specificulture: 'kk', fullName: 'Kazakh' },
            { specificulture: 'kk-KZ', fullName: 'Kazakh (Kazakhstan)' },
            { specificulture: 'kn', fullName: 'Kannada' },
            { specificulture: 'kn-IN', fullName: 'Kannada (India)' },
            { specificulture: 'ko', fullName: 'Korean' },
            { specificulture: 'ko-KR', fullName: 'Korean (Korea)' },
            { specificulture: 'kok', fullName: 'Konkani' },
            { specificulture: 'kok-IN', fullName: 'Konkani (India)' },
            { specificulture: 'ky', fullName: 'Kyrgyz' },
            { specificulture: 'ky-KG', fullName: 'Kyrgyz (Kyrgyzstan)' },
            { specificulture: 'lt', fullName: 'Lithuanian' },
            { specificulture: 'lt-LT', fullName: 'Lithuanian (Lithuania)' },
            { specificulture: 'lv', fullName: 'Latvian' },
            { specificulture: 'lv-LV', fullName: 'Latvian (Latvia)' },
            { specificulture: 'mi', fullName: 'Maori' },
            { specificulture: 'mi-NZ', fullName: 'Maori (New Zealand)' },
            { specificulture: 'mk', fullName: 'FYRO Macedonian' },
            { specificulture: 'mk-MK', fullName: 'FYRO Macedonian (Former Yugoslav Republic of Macedonia)' },
            { specificulture: 'mn', fullName: 'Mongolian' },
            { specificulture: 'mn-MN', fullName: 'Mongolian (Mongolia)' },
            { specificulture: 'mr', fullName: 'Marathi' },
            { specificulture: 'mr-IN', fullName: 'Marathi (India)' },
            { specificulture: 'ms', fullName: 'Malay' },
            { specificulture: 'ms-BN', fullName: 'Malay (Brunei Darussalam)' },
            { specificulture: 'ms-MY', fullName: 'Malay (Malaysia)' },
            { specificulture: 'mt', fullName: 'Maltese' },
            { specificulture: 'mt-MT', fullName: 'Maltese (Malta)' },
            { specificulture: 'nb', fullName: 'Norwegian (Bokm?l)' },
            { specificulture: 'nb-NO', fullName: 'Norwegian (Bokm?l) (Norway)' },
            { specificulture: 'nl', fullName: 'Dutch' },
            { specificulture: 'nl-BE', fullName: 'Dutch (Belgium)' },
            { specificulture: 'nl-NL', fullName: 'Dutch (Netherlands)' },
            { specificulture: 'nn-NO', fullName: 'Norwegian (Nynorsk) (Norway)' },
            { specificulture: 'ns', fullName: 'Northern Sotho' },
            { specificulture: 'ns-ZA', fullName: 'Northern Sotho (South Africa)' },
            { specificulture: 'pa', fullName: 'Punjabi' },
            { specificulture: 'pa-IN', fullName: 'Punjabi (India)' },
            { specificulture: 'pl', fullName: 'Polish' },
            { specificulture: 'pl-PL', fullName: 'Polish (Poland)' },
            { specificulture: 'ps', fullName: 'Pashto' },
            { specificulture: 'ps-AR', fullName: 'Pashto (Afghanistan)' },
            { specificulture: 'pt', fullName: 'Portuguese' },
            { specificulture: 'pt-BR', fullName: 'Portuguese (Brazil)' },
            { specificulture: 'pt-PT', fullName: 'Portuguese (Portugal)' },
            { specificulture: 'qu', fullName: 'Quechua' },
            { specificulture: 'qu-BO', fullName: 'Quechua (Bolivia)' },
            { specificulture: 'qu-EC', fullName: 'Quechua (Ecuador)' },
            { specificulture: 'qu-PE', fullName: 'Quechua (Peru)' },
            { specificulture: 'ro', fullName: 'Romanian' },
            { specificulture: 'ro-RO', fullName: 'Romanian (Romania)' },
            { specificulture: 'ru', fullName: 'Russian' },
            { specificulture: 'ru-RU', fullName: 'Russian (Russia)' },
            { specificulture: 'sa', fullName: 'Sanskrit' },
            { specificulture: 'sa-IN', fullName: 'Sanskrit (India)' },
            { specificulture: 'se', fullName: 'Sami (Northern)' },
            { specificulture: 'se-FI', fullName: 'Sami (Northern) (Finland)' },
            { specificulture: 'se-FI', fullName: 'Sami (Skolt) (Finland)' },
            { specificulture: 'se-FI', fullName: 'Sami (Inari) (Finland)' },
            { specificulture: 'se-NO', fullName: 'Sami (Northern) (Norway)' },
            { specificulture: 'se-NO', fullName: 'Sami (Lule) (Norway)' },
            { specificulture: 'se-NO', fullName: 'Sami (Southern) (Norway)' },
            { specificulture: 'se-SE', fullName: 'Sami (Northern) (Sweden)' },
            { specificulture: 'se-SE', fullName: 'Sami (Lule) (Sweden)' },
            { specificulture: 'se-SE', fullName: 'Sami (Southern) (Sweden)' },
            { specificulture: 'sk', fullName: 'Slovak' },
            { specificulture: 'sk-SK', fullName: 'Slovak (Slovakia)' },
            { specificulture: 'sl', fullName: 'Slovenian' },
            { specificulture: 'sl-SI', fullName: 'Slovenian (Slovenia)' },
            { specificulture: 'sq', fullName: 'Albanian' },
            { specificulture: 'sq-AL', fullName: 'Albanian (Albania)' },
            { specificulture: 'sr-BA', fullName: 'Serbian (Latin) (Bosnia and Herzegovina)' },
            { specificulture: 'sr-BA', fullName: 'Serbian (Cyrillic) (Bosnia and Herzegovina)' },
            { specificulture: 'sr-SP', fullName: 'Serbian (Latin) (Serbia and Montenegro)' },
            { specificulture: 'sr-SP', fullName: 'Serbian (Cyrillic) (Serbia and Montenegro)' },
            { specificulture: 'sv', fullName: 'Swedish' },
            { specificulture: 'sv-FI', fullName: 'Swedish (Finland)' },
            { specificulture: 'sv-SE', fullName: 'Swedish (Sweden)' },
            { specificulture: 'sw', fullName: 'Swahili' },
            { specificulture: 'sw-KE', fullName: 'Swahili (Kenya)' },
            { specificulture: 'syr', fullName: 'Syriac' },
            { specificulture: 'syr-SY', fullName: 'Syriac (Syria)' },
            { specificulture: 'ta', fullName: 'Tamil' },
            { specificulture: 'ta-IN', fullName: 'Tamil (India)' },
            { specificulture: 'te', fullName: 'Telugu' },
            { specificulture: 'te-IN', fullName: 'Telugu (India)' },
            { specificulture: 'th', fullName: 'Thai' },
            { specificulture: 'th-TH', fullName: 'Thai (Thailand)' },
            { specificulture: 'tl', fullName: 'Tagalog' },
            { specificulture: 'tl-PH', fullName: 'Tagalog (Philippines)' },
            { specificulture: 'tn', fullName: 'Tswana' },
            { specificulture: 'tn-ZA', fullName: 'Tswana (South Africa)' },
            { specificulture: 'tr', fullName: 'Turkish' },
            { specificulture: 'tr-TR', fullName: 'Turkish (Turkey)' },
            { specificulture: 'tt', fullName: 'Tatar' },
            { specificulture: 'tt-RU', fullName: 'Tatar (Russia)' },
            { specificulture: 'ts', fullName: 'Tsonga' },
            { specificulture: 'uk', fullName: 'Ukrainian' },
            { specificulture: 'uk-UA', fullName: 'Ukrainian (Ukraine)' },
            { specificulture: 'ur', fullName: 'Urdu' },
            { specificulture: 'ur-PK', fullName: 'Urdu (Islamic Republic of Pakistan)' },
            { specificulture: 'uz', fullName: 'Uzbek (Latin)' },
            { specificulture: 'uz-UZ', fullName: 'Uzbek (Latin) (Uzbekistan)' },
            { specificulture: 'uz-UZ', fullName: 'Uzbek (Cyrillic) (Uzbekistan)' },
            { specificulture: 'vi', fullName: 'Vietnamese', icon: 'flag-icon-vn' },
            { specificulture: 'vi-VN', fullName: 'Vietnamese (Viet Nam)', icon: 'flag-icon-vn' },
            { specificulture: 'xh', fullName: 'Xhosa' },
            { specificulture: 'xh-ZA', fullName: 'Xhosa (South Africa)' },
            { specificulture: 'zh', fullName: 'Chinese' },
            { specificulture: 'zh-CN', fullName: 'Chinese (S)' },
            { specificulture: 'zh-HK', fullName: 'Chinese (Hong Kong)' },
            { specificulture: 'zh-MO', fullName: 'Chinese (Macau)' },
            { specificulture: 'zh-SG', fullName: 'Chinese (Singapore)' },
            { specificulture: 'zh-TW', fullName: 'Chinese (T)' },
            { specificulture: 'zu', fullName: 'Zulu' },
            { specificulture: 'zu-ZA', fullName: 'Zulu (South Africa)' },

        ]
        $scope.icons = [
            'flag-icon-us',
            'flag-icon-vn',
            'flag-icon-gb',
            'flag-icon-fr',
            'flag-icon-cn',
            'flag-icon-be',
        ];
        $scope.activedCulture = null;

        $scope.relatedCultures = [];

        $rootScope.isBusy = false;

        $scope.data = {
            pageIndex: 0,
            pageSize: 1,
            totalItems: 0
        };

        $scope.errors = [];

        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        $scope.getCulture = async function (id) {
            $rootScope.isBusy = true;
            var resp = await cultureServices.getCulture(id, 'be');
            if (resp && resp.isSucceed) {
                $scope.activedCulture = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.syncTemplates = async function (id) {
            var response = await cultureServices.syncTemplates(id);
            if (response.isSucceed) {
                $scope.activedCulture = response.data;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };

        $scope.loadCulture = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await cultureServices.getCulture(id, 'be');
            if (response.isSucceed) {
                $scope.activedCulture = response.data;
                if (!id) {
                    $scope.activedCulture.icon = $scope.icons[0];
                }
                $scope.$apply();

            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };
        $scope.loadCultures = async function (pageIndex) {
            if (pageIndex != undefined) {
                $scope.request.pageIndex = pageIndex;
            }
            if ($scope.request.fromDate != null) {
                var d = new Date($scope.request.fromDate);
                $scope.request.fromDate = d.toISOString();
            }
            if ($scope.request.toDate != null) {
                $scope.request.toDate = $scope.request.toDate.toISOString();
            }
            var resp = await cultureServices.getCultures($scope.request);
            if (resp && resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, culture) {

                    $.each($scope.activedCultures, function (i, e) {
                        if (e.cultureId == culture.id) {
                            culture.isHidden = true;
                        }
                    })
                })
                setTimeout(function () {
                    $('[data-toggle="popover"]').popover({
                        html: true,
                        content: function () {
                            var content = $(this).next('.popover-body');
                            return $(content).html();
                        },
                        title: function () {
                            var title = $(this).attr("data-popover-content");
                            return $(title).children(".popover-heading").html();
                        }
                    });
                }, 200);
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.saveCulture = async function (culture) {
            culture.content = $('.editor-content').val();
            var resp = await cultureServices.saveCulture(culture);
            if (resp && resp.isSucceed) {
                $scope.activedCulture = resp.data;
                $rootScope.showMessage('success', 'success');
                $rootScope.isBusy = false;
                $rootScope.updateSettings();
                window.location.href = '/backend/culture/list';
                $scope.$apply();

            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.removeCulture = function (id) {
            $rootScope.showConfirm($scope, 'removeCultureConfirmed', [id], null, 'Remove Culture', 'Are you sure');
        }

        $scope.removeCultureConfirmed = async function (id) {
            var result = await cultureServices.removeCulture(id);
            if (result.isSucceed) {
                $rootScope.updateSettings();
                window.location.href = '/backend/culture/list';
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }

        $scope.changeIcon = function (icon) {
            $scope.activedCulture.icon = icon;
        }
    }]);
