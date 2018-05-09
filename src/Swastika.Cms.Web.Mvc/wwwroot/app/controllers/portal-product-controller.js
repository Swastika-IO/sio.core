'use strict';

///////////////////////////////////////
//
//  PRODUCT CONTROLLER
//
///////////////////////////////////////
app.controller('ProductController', function ProductController($scope) {
    // Actived product
    $scope.activedProduct = null;

    // Related products array
    $scope.relatedProducts = [];

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

    // Load product from API
    $scope.loadProduct = function (productId, isNew) {
        $scope.isBusy = true;
        var url = '';

        if (isNew) {
            // If create product then call create API
            url = '/api/' + $scope.currentLanguage + '/product/create';
        }
        else {
            // Else create product then call get API
            url = '/api/' + $scope.currentLanguage + '/product/details/be/' + productId;//byProduct/' + productId;
        }

        // Ajax setting
        $scope.settings.method = "GET";
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = JSON.stringify($scope.request);

        // Ajax call
        $.ajax($scope.settings).done(function (response) {
            // Done

            if (response.isSucceed) {
                // If reponse is succeed
                $scope.activedProduct = response.data;
                $scope.initEditor();
            }

            $scope.isBusy = false;
            $scope.$apply();
        });
    };

    // Load list of product from API
    $scope.loadProducts = function (pageIndex) {       
        if (pageIndex != undefined) {
            $scope.request.pageIndex = pageIndex;
        }
        if ($scope.request.fromDate != null) {
            $scope.request.fromDate = $filter('date')($scope.request.fromDate, "yyyy-MM-dd");
        }
        if ($scope.request.toDate != null) {
            $scope.request.toDate = $filter('date')($scope.request.toDate, "yyyy-MM-dd");
        }
        var url = '/api/' + $scope.currentLanguage + '/product/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = JSON.stringify($scope.request);
        $scope.isBusy = true;
        $.ajax($scope.settings).done(function (response) {
            
            if (response.isSucceed) {
                // If ajax call is succeed
                ($scope.data = response.data);
                $("html, body").animate({ "scrollTop": "0px" }, 500);

                $.each($scope.data.items, function (i, product) {
                    $.each($scope.activedProducts, function (i, e) {
                        if (e.productId == product.id) {
                            product.isHidden = true;
                        }
                    })
                })

                $scope.isBusy = false;

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
        });
    };

    // Remove product
    $scope.removeProduct = function (productId) {
        if (confirm("Are you sure that you want to delete this product!?")) {

            // Set ajax call URL to remove product with product ID
            var url = '/api/' + $scope.currentLanguage + '/product/delete/' + productId;

            // Ajax call
            $.ajax({
                method: 'GET',
                url: url,
                success: function (data) {
                    // Ajax request is succeed then load product list again
                    $scope.loadProducts();
                    $scope.$apply();
                },
                error: function (a, b, c) {
                    // Write error content to console
                    console.log(a + " " + b + " " + c);
                }
            });
        }
    };

    // Save product
    $scope.saveProduct = function (product) {
        $scope.isBusy = true;
        product.content = $('.editor-content').val();
        var json = (angular.toJson(product));

        // Set ajax call URL to save product API
        var url = '/api/' + $scope.currentLanguage + '/product/save';

        // Ajax call
        $.ajax({
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            url: url,
            data: json,
            success: function (data) {
                //$scope.loadProducts();
                if (data.isSucceed) {
                    // Ajax request is succeed
                    $scope.activedProduct = data.data;
                    $scope.message.content = 'Success';
                    $scope.message.class = 'success';
                }
                else {
                    // Display error
                    $scope.errors = data.errors;
                }

                $("html, body").animate({ "scrollTop": "0px" }, 500);
                $scope.isBusy = false;
                $scope.$apply();
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
                $scope.isBusy = false;
                $scope.$apply();
            }
        });
    };

    // Add product's property
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