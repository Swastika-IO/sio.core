'use strict';
var app = angular.module('SwastikaPortal',
    ['ngRoute', 'ngFileUpload', 'LocalStorageModule']);
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
}).directive('imageonload', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('load', function () {
            });
            element.bind('error', function () {
            });
        }
    };
}).filter('utcToLocal', Filter);

app.run(['$rootScope', '$location', 'commonServices', function ($rootScope, $location, commonServices) {
   
    $rootScope.currentContext = $rootScope;
    $rootScope.errors = [];
    
    $rootScope.message = {
        title: 'test',
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

    $rootScope.$watch('isBusy', function (newValue, oldValue) {
        if (newValue) {
            $rootScope.message.content = '';
            $rootScope.errors = [];
        }
    });

    //type: success / info / danger / warning - bootstrap 
    $rootScope.showMessage = function (content, errors, type) {
        type = type || 'info';
        $rootScope.message.title = 'Result';
        $rootScope.message.content = content;
        $rootScope.message.errors = errors;
        $rootScope.message.class = type;
        $('#dlg-msg').modal("show");
    }
    
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