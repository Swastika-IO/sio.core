'use strict';
app.controller('ModuleDataController', function PhoneListController($scope) {
    $scope.data = null;

    $scope.currentLanguage = $('#curentLanguage').val();

    $scope.settings = {
        "async": true,
        "crossDomain": true,
        "url": "",
        "method": "POST",
        "headers": {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        "data": null
    };
    $scope.message = {
        class: 'alert-success',
        content: ''
    };
    $scope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    $scope.initModuleData = function (moduleId) {
        $.ajax({
            async: true,
            crossDomain: true,
            method: 'GET',
            url: '/api/' + $scope.currentLanguage + '/module-data/create/' + moduleId,
            success: function (response) {
                $scope.$apply($scope.data = response.data);
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    };
    $scope.saveModuleData = function () {
        $.ajax({
            method: 'POST',
            url: '/api/' + $scope.currentLanguage + '/module-data/save',
            data: $scope.data,
            success: function (response) {
                $scope.data = response.data;
                if (response.isSucceed) {
                    $scope.data = $scope.initModuleData($scope.data.moduleId);
                    $scope.message.class = 'alert-success';
                    $scope.message.content = 'success';
                }
                else {
                    $scope.message.class = 'alert-danger';
                    $scope.message.content = response.errors;
                }
                console.log(response);
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    }
    $(document).ready(function () {
        //$scope.initModuleData();
    });
});
