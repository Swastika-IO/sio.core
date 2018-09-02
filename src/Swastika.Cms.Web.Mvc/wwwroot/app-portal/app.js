'use strict';
var app = angular.module('SwastikaPortal', ['ngRoute', 'components', 'ngFileUpload', 'LocalStorageModule',
    'bw.paging', 'dndLists', 'ngTagsInput', 'ngSanitize']);
//var serviceBase = 'http://crickettours.asia';

app.run(['$rootScope', '$location', 'CommonServices', 'AuthService', 'TranslatorService',
    function ($rootScope, $location, commonServices, authService, translatorService) {
        $rootScope.currentContext = $rootScope;
        $rootScope.isBusy = false;
        $rootScope.translator = translatorService;
        $rootScope.errors = [];
        $rootScope.breadCrumbs = [];
        $rootScope.message = {
            title: '',
            content: '',
            errors: [],
            okFuncName: null,
            okArgs: [],
            cancelFuncName: null,
            cancelArgs: [],
            lblOK: 'OK',
            lblCancel: 'Cancel',
            context: $rootScope
        };

        $rootScope.swStatus = [
            'Deleted',
            'Preview',
            'Published',
            'Draft',
            'Schedule'
        ];

        $rootScope.orders = [
            {
                value: 'CreatedDateTime',
                title: 'Created Date'
            }
            ,
            {
                value: 'Priority',
                title: 'Priority'
            },

            {
                value: 'Title',
                title: 'Title'
            }
        ];
        $rootScope.directions = [
            {
                value: '0',
                title: 'Asc'
            },
            {
                value: '1',
                title: 'Desc'
            }
        ];
        $rootScope.pageSizes = [
            '5',
            '10',
            '15',
            '20'
        ];
        $rootScope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'CreatedDateTime',
            direction: '1',
            fromDate: null,
            toDate: null,
            keyword: ''
        };
        $rootScope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };
        $rootScope.generateKeyword = function (src, character) {
            return src.replace(/[^a-zA-Z0-9]+/g, character)
                .replace(/([A-Z]+)([A-Z][a-z])/g, '$1-$2')
                .replace(/([a-z])([A-Z])/g, '$1-$2')
                .replace(/([0-9])([^0-9])/g, '$1-$2')
                .replace(/([^0-9])([0-9])/g, '$1-$2')
                .replace(/-+/g, character)
                .toLowerCase();
        };

        $rootScope.logOut = function () {
            authService.logOut();
            //$location.path('/portal/login');
            window.top.location.href = '/portal/login';
        };

        $rootScope.updateSettings = function () {
            commonServices.removeSettings();
            commonServices.fillSettings($rootScope.settings.lang).then(function (response) {
                $rootScope.settings = response;

            });
            $rootScope.isBusy = false;
        };
        $rootScope.executeFunctionByName = async function (functionName, args, context) {
            if (functionName !== null) {
                var namespaces = functionName.split(".");
                var func = namespaces.pop();
                for (var i = 0; i < namespaces.length; i++) {
                    context = context[namespaces[i]];
                }
                functionName = null;
                return context[func].apply(this, args);
            }
        };

        $rootScope.showConfirm = function (context, okFuncName, okArgs, cancelFuncName, title, msg
            , cancelArgs, lblOK, lblCancel) {
            $rootScope.confirmMessage = {
                title: title,
                content: msg,
                context: context,
                okFuncName: okFuncName,
                okArgs: okArgs,
                cancelFuncName: cancelFuncName,
                cancelArgs: cancelArgs,
                lblOK: lblOK ? lblOK : 'OK',
                lblCancel: lblCancel ? lblCancel : 'Cancel'
            };
            $('#dlg-confirm-msg').modal('show');
        };

        $rootScope.preview = function (type, value) {
            $rootScope.previewObject = {
                title: 'Preview',
                type: type,
                value: value
            };
            $('#dlg-preview-popup').modal('show');
        };

        $rootScope.configurations = {
            core: {},
            plugins: {
                btnsDef: {
                    // Customizables dropdowns
                    image: {
                        dropdown: ['insertImage', 'upload', 'base64', 'noembed'],
                        ico: 'insertImage'
                    }
                },
                btns: [
                    ['table'],
                    ['undo', 'redo'],
                    ['formatting'],
                    ['strong', 'em', 'del', 'underline'],
                    ['link'],
                    ['image'],
                    ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
                    ['unorderedList', 'orderedList'],
                    ['foreColor', 'backColor'],
                    ['preformatted'],
                    ['horizontalRule'],
                    ['fullscreen'],
                    ['viewHTML']
                ],
                plugins: {
                    // Add imagur parameters to upload plugin
                    upload: {
                        serverPath: 'https://api.imgur.com/3/image',
                        fileFieldName: 'image',
                        headers: {
                            'Authorization': 'Client-ID 9e57cb1c4791cea'
                        },
                        urlPropertyName: 'data.link'
                    }
                }
            },
            dataTypes: [
                { title: 'string', value: 0 },
                { title: 'int', value: 1 },
                { title: 'image', value: 2 },
                { title: 'codeEditor', value: 4 },
                { title: 'html', value: 5 },
                { title: 'textArea', value: 6 },
                { title: 'boolean', value: 7 },
                { title: 'mdTextArea', value: 8 },
                { title: 'date', value: 9 },
                { title: 'datetime', value: 10 }
            ]
        };

        $rootScope.initEditor = function () {
            setTimeout(function () {

                $.each($('.code-editor'), function (i, e) {
                    var container = $(this);
                    var editor = ace.edit(e);
                    if (container.hasClass('json')) {
                        editor.session.setMode("ace/mode/json");
                    }
                    else {
                        editor.session.setMode("ace/mode/razor");
                    }
                    editor.setTheme("ace/theme/chrome");
                    //editor.setReadOnly(true);
                    editor.$blockScrolling = Infinity;
                    editor.session.setUseWrapMode(true);
                    editor.setOptions({
                        maxLines: Infinity
                    });
                    editor.getSession().on('change', function (e) {
                        // e.type, etc
                        $(container).parent().find('.code-content').val(editor.getValue());
                    });
                });

                $.each($('.editor-content'), function (i, e) {
                    var $textArea = $(e);
                    $textArea.trumbowyg($rootScope.configurations.plugins);

                });
            }, 200);
        };

        $rootScope.showErrors = function (errors) {
            if (errors.length) {

                $.each(errors, function (i, e) {
                    $rootScope.showMessage(e, 'danger');
                });
            }
            else {
                $rootScope.showMessage('Server Errors', 'danger');
            }
        };

        $rootScope.showMessage = function (content, type) {
            var from = 'bottom';
            var align = 'right';
            $.notify({
                icon: "now-ui-icons ui-1_bell-53",
                message: $rootScope.translate(content)

            }, {
                    type: type,
                    timer: 2000,
                    placement: {
                        from: from,
                        align: align
                    }
                });
        };

        $rootScope.translate = function (keyword, isWrap, defaultText) {
            if ($rootScope.settings && ($rootScope.translator || $rootScope.isBusy)) {
                return $rootScope.translator.get(keyword, isWrap, defaultText);
            }
            else {
                return keyword || defaultText;
            }
        };

        $rootScope.$watch('isBusy', function (newValue, oldValue) {
            if (newValue) {
                $rootScope.message.content = '';
                $rootScope.errors = [];
            }
        });
        $rootScope.$watch('breadCrumbs', function (newValue, oldValue) {
            if (newValue) {
                //console.log(newValue);
            }
        });
        $rootScope.$on("$locationChangeEnd", function (event, next, current) {
            console.log(event, next, current);
            // handle route changes     
            //$rootScope.breadCrumbs = [
            //    {
            //        url: '/backend/articles',
            //        title: 'articles'
            //    }, {
            //        url: '',
            //        title: 'list'
            //    }
            //];
        });


    }]);

function Filter($filter) {
    return function (utcDateString, format) {
        // return if input date is null or undefined
        if (!utcDateString) {
            return;
        }

        // append 'Z' to the date string to indicate UTC time if the timezone isn't already specified
        if (utcDateString.indexOf('Z') === -1 && utcDateString.indexOf('+') === -1) {
            utcDateString += 'Z';
        }

        // convert and format date using the built in angularjs date filter
        return $filter('date')(utcDateString, format);
    };
}
var modules = angular.module('components', []);