'use strict';

///////////////////////////////////////
//
//  MODULE CONTROLLER
//
///////////////////////////////////////
app.controller('ModuleController', function ModuleController($scope) {
    // Actived module
    $scope.activedModule = null;

    // Related modules array
    $scope.relatedModules = [];

    // Data array
    $scope.data = [];

    // Error array
    $scope.errors = [];

    // Message object
    $scope.message = {
        class: 'info',
        content: ''
    }

    // Range ???
    $scope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    // Load module from API
    $scope.loadModule = function (moduleId, isNew) {
        $rootScope.isBusy = true;
        var url = '';

        if (isNew) {
            // If create module then call create API
            url = '/api/' + $scope.currentLanguage + '/module/create';
        }
        else {
            // Else create module then call get API
            url = '/api/' + $scope.currentLanguage + '/module/details/be/' + moduleId;//byModule/' + moduleId;
        }

        // Ajax setting
        $scope.settings.method = "GET";
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = $scope.request;

        // Ajax call
        $.ajax($scope.settings).done(function (response) {
            // Done

            if (response.isSucceed) {
                // If reponse is succeed
                $scope.activedModule = response.data;
                $scope.initEditor();
            }

            $rootScope.isBusy = false;
            $scope.$apply();
        });
    };

    // Load list of module from API
    $scope.loadModules = function (pageIndex) {
        $rootScope.isBusy = true;

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

        // Set ajax request URL for get all modules
        var url = '/api/' + $scope.currentLanguage + '/module/list';//byModule/' + moduleId;

        // Ajax call
        $.ajax({
            method: 'POST',
            url: url,
            data: $scope.request,
            success: function (response) {
                //$scope.loadArticle();
                if (response.isSucceed) {
                    // If ajax call is succeed
                    ($scope.data = response.data);
                    $("html, body").animate({ "scrollTop": "0px" }, 500);

                    $.each($scope.data.items, function (i, module) {
                        $.each($scope.activedModules, function (i, e) {
                            if (e.moduleId == module.id) {
                                module.isHidden = true;
                            }
                        })
                    })

                    $rootScope.isBusy = false;

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
                    alert('failed! ' + data.errors);
                }
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
            }
        });
    };

    // Remove module
    $scope.removeModule = function (moduleId) {
        if (confirm("Are you sure that you want to delete this module!?")) {

            // Set ajax call URL to remove module with module ID
            var url = '/api/' + $scope.currentLanguage + '/module/delete/' + moduleId;

            // Ajax call
            $.ajax({
                method: 'GET',
                url: url,
                success: function (data) {
                    // Ajax request is succeed then load module list again
                    $scope.loadModules();
                    $scope.$apply();
                },
                error: function (a, b, c) {
                    // Write error content to console
                    console.log(a + " " + b + " " + c);
                }
            });
        }
    };

    // Save module
    $scope.saveModule = function (module) {
        $rootScope.isBusy = true;
        module.content = $('.editor-content').val();
        var json = (angular.toJson(module));

        // Set ajax call URL to save module API
        var url = '/api/' + $scope.currentLanguage + '/module/save';

        // Ajax call
        $.ajax({
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            url: url,
            data: json,
            success: function (data) {
                //$scope.loadModules();
                if (data.isSucceed) {
                    // Ajax request is succeed
                    $scope.activedModule = data.data;
                    $scope.message.content = 'Success';
                    $scope.message.class = 'success';
                }
                else {
                    // Display error
                    $scope.errors = data.errors;
                }

                $("html, body").animate({ "scrollTop": "0px" }, 500);
                $rootScope.isBusy = false;
                $scope.$apply();
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        });
    };

    // Add module's property
    $scope.addProperty = function (type) {
        var i = $(".property").length;

        $.ajax({
            method: 'GET',
            url: '/' + $scope.currentLanguage + '/Portal/' + type + '/AddEmptyProperty/' + i,
            success: function (data) {
                $('#tbl-properties > tbody').append(data);
                $(data).find('.prop-data-type').trigger('change');
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
            }
        });
    }

    $scope.$watch('isBusy', function (newValue, oldValue) {
        if (newValue) {
            $scope.message.content = '';
            $scope.errors = [];
        }
    });
});