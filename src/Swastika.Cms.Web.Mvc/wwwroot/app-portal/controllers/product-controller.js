'use strict';
app.controller('ProductController', ['$scope', '$rootScope', 'ngAppSettings','$routeParams', '$timeout', '$location', 'AuthService', 'ProductServices',
    function ($scope, $rootScope, ngAppSettings, $routeParams, $timeout, $location, authService, productServices) {
        $scope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: ngAppSettings.swStatus[1],
            orderBy: 'CreatedDateTime',
            direction: '1',
            fromDate: null,
            toDate: null,
            keyword: ''
        };
        
        $scope.activedProduct = null;
        $scope.relatedProducts = [];
        $scope.isBusy = false;
        $scope.data = [];
        $scope.errors = [];
        $scope.message = {
            class: 'info',
            content: ''
        };
        $scope.lang = $('#lang').val();
        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        $scope.getProduct = function (id) {
            if (!$scope.isBusy) {
                $scope.isBusy = true;
                productServices.getProduct(id, 'be').then(function (response) {
                    if (response.isSucceed) {
                        $scope.activedProduct = response.data;
                        $rootScope.initEditor();
                    }
                    $scope.isBusy = false;
                    $scope.$apply();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $scope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    $scope.$apply();
                });
            }
        };

        $scope.initProduct = function () {
            if (!$scope.isBusy) {
                $scope.isBusy = true;
                productServices.initProduct('be').then(function (response) {
                    if (response.isSucceed) {
                        $scope.activedProduct = response.data;
                        $rootScope.initEditor();
                    }
                    $scope.isBusy = false;
                    $scope.$apply();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $scope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);                    
                });
            }
        };

        $scope.loadProduct = function () {
            if (!$scope.isBusy) {
                $scope.isBusy = true;
                var id = $routeParams.id;

                productServices.getProduct(id,'be').then(function (response) {
                    if (response.data.isSucceed) {
                        $scope.activedProduct = response.data.data;
                        $rootScope.initEditor();
                    }
                    else {
                        alert('failed! ' + data.errors);
                    }

                }, function (a, b, c) {
                    errors.push(a, b, c);
                    $scope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    
                });
            }
        };

        $scope.loadProducts = function (pageIndex) {
            if (!$scope.isBusy) {
                $scope.isBusy = true;
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

                productServices.getProducts($scope.request).then(function (result) {
                    var resp = result.data;
                    if (resp.isSucceed) {

                        ($scope.data = resp.data);
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
                    }
                    else {
                        alert('failed! ' + data.errors);
                    }
                }, function (a, b, c) {
                    errors.push(a, b, c);
                    $scope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    $scope.$apply();
                });
            }
        };

        $scope.removeProduct = function (id) {
            if (confirm("Are you sure!")) {
                productServices.removeProduct(id).then(function (response) {
                    $scope.loadProducts();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $scope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                });;
            }
        };
        $scope.saveProduct = function (product) {
            if (!isBusy) {

                $scope.isBusy = true;
                product.content = $('.editor-content').val();

                productServices.saveProduct(product).then(function (response) {
                    if (data.isSucceed) {
                        $scope.activedProduct = data.data;
                        $scope.message.content = 'Thành công';
                        $scope.message.class = 'success';
                    }
                    else {
                        $scope.errors = data.errors;
                    }
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    $scope.isBusy = false;
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $scope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                });
            }
        };

        $scope.$watch('isBusy', function (newValue, oldValue) {
            if (newValue) {
                $scope.message.content = '';
                $scope.errors = [];
            }
        });
    }]);
