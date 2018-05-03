'use strict';
var appName = 'SwastikaPortal';
var app = angular.module(appName, ['components', 'ngFileUpload']);
var serviceBase = "/";
app.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });

                event.preventDefault();
            }
        });
    };
}).directive('file', function () {
    return {
        scope: {
            file: '='
        },
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var files = event.target.files;
                var file = files[0];
                scope.file = file;
                scope.$apply();
            });
        }
    };
});
app.run(['$rootScope', '$location', async function ($rootScope, $location) {
    $rootScope.currentContext = $rootScope;
    $rootScope.errors = [];
    $rootScope.message = {
        title: '',
        value: '',
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
    ]
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
    ]
    $rootScope.pageSizes = [
        '5',
        '10',
        '15',
        '20'
    ]
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
                ['viewHTML'],
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
                ['fullscreen']
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
        }
    };
    $rootScope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    $rootScope.$watch('isBusy', function (newValue, oldValue) {
        if (newValue) {
            $rootScope.message.content = '';
            $rootScope.errors = [];
        }
    });
    $rootScope.showErrors = function (errors) {
        $rootScope.errors = errors;
        $("html, body").animate({ "scrollTop": "0px" }, 500);
    }
    $rootScope.logOut = function () {
        authService.logOut();
        $location.path('/backend/login');
    };
    $rootScope.executeFunctionByName = function (functionName, args, context) {
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

    $rootScope.showConfirm = function (context, okFuncName, okArgs, cancelFuncName, title, msg, cancelArgs, lblOK, lblCancel) {
        $rootScope.message = {
            title: title,
            value: msg,
            context: $scope,
            okFuncName: okFuncName,
            okArgs: okArgs,
            cancelFuncName: cancelArgs,
            cancelArgs: cancelArgs,
            lblOK: lblOK,
            lblCancel: lblCancel
        };
        $('#modal-confirm').modal('show');
    };
    $rootScope.initEditor = function () {
        setTimeout(function () {
            // Init Code editor
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

                editor.session.setUseWrapMode(true);
                editor.setOptions({
                    maxLines: Infinity
                });
                editor.getSession().on('change', function (e) {
                    // e.type, etc
                    $(container).parent().find('.code-content').val(editor.getValue());
                });
            })
            $.each($('.editor-content'), function (i, e) {
                var $demoTextarea = $(e);
                $demoTextarea.trumbowyg($rootScope.configurations.plugins);
            });
        }, 200)
    }
}]);
app.filter('utcToLocal', Filter).constant('ngAuthSettings', {
    apiServiceBaseUri: '/',
    clientId: 'ngAuthApp',
    facebookAppId: '464285300363325'
});;
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