'use strict';
var app = angular.module('SwastikaPortal', ['ngRoute', 'components', 'ngFileUpload', 'ngAnimate', 'LocalStorageModule', 'angular-loading-bar', 'ngLoadScript', 'ckeditor', 'bw.paging']);
var serviceBase = "/";

app.config(function ($routeProvider, $locationProvider, $sceProvider) {
    $routeProvider.when("/admin", {
        controller: "dashboardController",
        templateUrl: "/app-portal/views/dashboard.html"
    });
});

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
})
    .filter('utcToLocal', Filter)
    .constant('ngAuthSettings', {
        apiServiceBaseUri: '/',
        clientId: 'ngAuthApp',
        facebookAppId: '464285300363325'
});

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