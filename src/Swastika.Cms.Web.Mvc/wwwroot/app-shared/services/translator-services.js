'use strict';
app.service('translator', ['$rootScope', function ($rootScope) {

    var translator = $rootScope.translator;

    this.get = function (keyword) {
        return translator[keyword] || '[' + keyword + ']';
    };
}]);
