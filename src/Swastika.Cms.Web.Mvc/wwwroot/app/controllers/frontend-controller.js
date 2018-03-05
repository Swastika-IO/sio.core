'use strict';
app.controller('ModuleDataController', function PhoneListController($scope) {
    var vm = this
    vm.data = null;

    vm.currentLanguage = $('#curentLanguage').val();

    vm.settings = {
        "async": true,
        "crossDomain": true,
        "url": "",
        "method": "POST",
        "headers": {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        "data": null
    };
    vm.message = {
        class: 'alert-success',
        content: ''
    };
    vm.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    vm.initModuleData = function (moduleId) {
        $.ajax({
            async: true,
            crossDomain: true,
            method: 'GET',
            url: '/api/' + vm.currentLanguage + '/module-data/create/' + moduleId,
            success: function (response) {
                vm.data = response.data;
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    };
    vm.saveModuleData = function () {
        $.ajax({
            method: 'POST',
            url: '/api/' + vm.currentLanguage + '/module-data/save',
            data: vm.data,
            success: function (response) {
                vm.data = response.data;
                if (response.isSucceed) {
                    vm.data = vm.initModuleData(vm.data.moduleId);
                    vm.message.class = 'alert-success';
                    vm.message.content = 'success';
                }
                else {
                    vm.message.class = 'alert-danger';
                    vm.message.content = response.errors;
                }
                console.log(response);
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    }
});
